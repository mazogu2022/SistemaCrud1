using System;
using System.Collections.Generic; // Para listas y colecciones
using System.Linq; // Para operaciones LINQ, si las usas
using System.Windows.Forms; // Para controles de formulario como DataGridView
using SistemaCrud.Logica; // Para acceder a la clase lógica L_Tbtitular
using SistemaCrud.Modelo; // Para usar el modelo M_Titular

namespace SistemaCrud
{
    public partial class FrmListado : Form
    {
        public FrmListado()
        {
            InitializeComponent();
        }

        private void FrmListado_Load(object sender, EventArgs e)
        {
            ListarTbtitular(); // Cargar los datos al abrir el formulario
        }

        private void ListarTbtitular()
        {
            try
            {
                // Obtener la lista de datos desde la lógica
                var lista = L_Titular.Instancia.Listar();

                // Asignar la lista como fuente de datos del DataGridView
                DgvListado.DataSource = lista;

                // Verifica y oculta la columna Idempresa (si existe)
                if (DgvListado.Columns.Contains("Idempresa"))
                {
                    DgvListado.Columns["Idempresa"].Visible = false; // Ocultar columna ID
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al listar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Abrir el formulario para un nuevo registro
            FrmNuevo frm = new FrmNuevo();
            frm.ShowDialog(); // Mostrar el formulario como cuadro de diálogo modal
            ListarTbtitular(); // Actualizar la lista después de guardar
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (DgvListado.SelectedRows.Count > 0)
            {
                try
                {
                    // Validar que Idempresa esté disponible
                    string idempresa = DgvListado.SelectedRows[0].Cells["Idempresa"].Value?.ToString();

                    if (string.IsNullOrEmpty(idempresa))
                    {
                        MessageBox.Show("El registro seleccionado no tiene un ID válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Obtener los datos de la fila seleccionada
                    string empresa = DgvListado.SelectedRows[0].Cells["Empresa"].Value.ToString();
                    string identificador = DgvListado.SelectedRows[0].Cells["Identificador"].Value.ToString();
                    string domiciliolegal = DgvListado.SelectedRows[0].Cells["Domiciliolegal"].Value.ToString();
                    string distrito = DgvListado.SelectedRows[0].Cells["Distrito"].Value.ToString();
                    string provincia = DgvListado.SelectedRows[0].Cells["Provincia"].Value.ToString();
                    string departamento = DgvListado.SelectedRows[0].Cells["Departamento"].Value.ToString();
                    string ruc = DgvListado.SelectedRows[0].Cells["Ruc"].Value.ToString();
                    string telefono = DgvListado.SelectedRows[0].Cells["Telefono"].Value.ToString();
                    string correo = DgvListado.SelectedRows[0].Cells["Correo"].Value.ToString();
                    string representante = DgvListado.SelectedRows[0].Cells["Representante"].Value.ToString();
                    string dni = DgvListado.SelectedRows[0].Cells["Dni"].Value.ToString();
                    string llama1 = DgvListado.SelectedRows[0].Cells["Llama1"].Value.ToString();
                    string llama2 = DgvListado.SelectedRows[0].Cells["Llama2"].Value.ToString();
                    string llama3 = DgvListado.SelectedRows[0].Cells["Llama3"].Value.ToString();
                    string comentarios = DgvListado.SelectedRows[0].Cells["Comentarios"].Value.ToString();

                    // Pasar los datos al formulario FrmNuevo
                    FrmNuevo frm = new FrmNuevo
                    {
                        Idempresa = idempresa,
                        Empresa = empresa,
                        Identificador = identificador,
                        Domiciliolegal = domiciliolegal,
                        Distrito = distrito,
                        Provincia = provincia,
                        Departamento = departamento,
                        Ruc = ruc,
                        Telefono = telefono,
                        Correo = correo,
                        Representante = representante,
                        Dni = dni,
                        Llama1 = llama1,
                        Llama2 = llama2,
                        Llama3 = llama3,
                        Comentarios = comentarios
                    };

                    frm.ShowDialog(); // Mostrar el formulario como cuadro de diálogo modal
                    ListarTbtitular(); // Actualizar la lista después de modificar
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al intentar modificar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarTbtitular();
        }
        private void BuscarTbtitular()
        {
            try
            {
                // Obtener el texto ingresado en el cuadro de búsqueda
                string criterio = txtbuscar.Text.Trim().ToLower();

                // Obtener la lista completa desde la lógica
                var listaCompleta = L_Titular.Instancia.Listar();

                // Filtrar la lista por empresa o RUC
                var listaFiltrada = listaCompleta
                    .Where(x => (x.Empresa != null && x.Empresa.ToLower().Contains(criterio)) ||
                                (x.Ruc != null && x.Ruc.ToLower().Contains(criterio)))
                    .ToList();

                // Asignar la lista filtrada al DataGridView
                DgvListado.DataSource = listaFiltrada;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvListado.SelectedRows.Count > 0)
                {
                    string idempresa = DgvListado.SelectedRows[0].Cells["idempresa"].Value.ToString();
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        bool eliminado = L_Titular.Instancia.Eliminar(idempresa);
                        if (eliminado)
                            MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Error al eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ListarTbtitular();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un registro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar tbtitular: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
