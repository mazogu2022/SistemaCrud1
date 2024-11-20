using System;
using System.Windows.Forms;
using SistemaCrud.Logica; // Para L_Ubigeo
using SistemaCrud.Modelo; // Para tbubigeo

namespace SistemaCrud
{
    public partial class FrmUbigeo : Form
    {
        public string Distrito { get; private set; }
        public string Provincia { get; private set; }
        public string Departamento { get; private set; }
        public FrmUbigeo()
        {
            InitializeComponent();
            CargarUbigeo();
        }
        private void FrmUbigeo_Load(object sender, EventArgs e)
        {
            CargarUbigeo(); // Cargar los datos al abrir el formulario
        }
        private void CargarUbigeo()
        {
            try
            {
                // Llama al método Listar de L_Ubigeo para obtener todos los registros
                var lista = L_Ubigeo.Instancia.Listar();
                DgvUbigeo.DataSource = lista;

                // Configurar columnas
                if (DgvUbigeo.Columns["Distrito"] != null)
                {
                    DgvUbigeo.Columns["Distrito"].HeaderText = "Distrito";
                }
                if (DgvUbigeo.Columns["Provincia"] != null)
                {
                    DgvUbigeo.Columns["Provincia"].HeaderText = "Provincia";
                }
                if (DgvUbigeo.Columns["Departamento"] != null)
                {
                    DgvUbigeo.Columns["Departamento"].HeaderText = "Departamento";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbuscardistrito_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string criterio = txtbuscardistrito.Text.Trim();

                // Si el criterio está vacío, vuelve a cargar todos los datos
                if (string.IsNullOrEmpty(criterio))
                {
                    CargarUbigeo();
                    return;
                }

                // Llama al método Buscar de L_Ubigeo
                var resultados = L_Ubigeo.Instancia.Buscar(criterio);
                DgvUbigeo.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUbigeo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Obtener los datos de la fila seleccionada
                    Distrito = DgvUbigeo.Rows[e.RowIndex].Cells["Distrito"].Value.ToString();
                    Provincia = DgvUbigeo.Rows[e.RowIndex].Cells["Provincia"].Value.ToString();
                    Departamento = DgvUbigeo.Rows[e.RowIndex].Cells["Departamento"].Value.ToString();

                    DialogResult = DialogResult.OK; // Indicar que se seleccionó un valor correctamente
                    Close(); // Cerrar el formulario
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
