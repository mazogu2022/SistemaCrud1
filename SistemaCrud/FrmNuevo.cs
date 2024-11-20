using System;
using System.Windows.Forms;
using SistemaCrud.Logica; // Para L_Ubigeo
using SistemaCrud.Modelo; // Para tbubigeo

namespace SistemaCrud
{
    public partial class FrmNuevo : Form
    {
        public string Idempresa { get; set; }
        public string Empresa { get; set; }
        public string Identificador { get; set; }
        public string Domiciliolegal { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string Ruc { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Representante { get; set; }
        public string Dni { get; set; }
        public string Llama1 { get; set; }
        public string Llama2 { get; set; }
        public string Llama3 { get; set; }
        public string Comentarios { get; set; }
        public FrmNuevo()
        {
            InitializeComponent();
        }

        private void btnUbigeo_Click(object sender, EventArgs e)
        {
            var frmUbigeo = new FrmUbigeo();

            if (frmUbigeo.ShowDialog() == DialogResult.OK)
            {
                // Asignar los datos seleccionados al formulario actual
                txtDistrito.Text = frmUbigeo.Distrito;
                txtProvincia.Text = frmUbigeo.Provincia;
                txtDepartamento.Text = frmUbigeo.Departamento;
            }
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            txtLlama1.Text = "la empresa";
            txtLlama2.Text = "La empresa";
            txtLlama3.Text = "a la empresa";
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            txtLlama1.Text = "el señor";
            txtLlama2.Text = "El señor";
            txtLlama3.Text = "al señor";
        }

        private void rb3_CheckedChanged(object sender, EventArgs e)
        {
            txtLlama1.Text = "la señora";
            txtLlama2.Text = "La señora";
            txtLlama3.Text = "a la señora";
        }

        private void GuardarOModificartbtitular()
        {
            try
            {
                var obj = new M_Titular
                {
                    Empresa = txtEmpresa.Text,
                    Identificador = txtIdentificador.Text,
                    Domiciliolegal = txtDomiciliolegal.Text,
                    Distrito = txtDistrito.Text,
                    Provincia = txtProvincia.Text,
                    Departamento = txtDepartamento.Text,
                    Ruc = txtRuc.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    Representante = txtRepresentante.Text,
                    Dni = txtDni.Text,
                    Llama1 = txtLlama1.Text,
                    Llama2 = txtLlama2.Text,
                    Llama3 = txtLlama3.Text,
                    Comentarios = txtComentarios.Text
                };

                bool resultado;
                if (string.IsNullOrEmpty(Idempresa)) // Guardar nuevo registro
                {
                    resultado = L_Titular.Instancia.Guardar(obj);
                    if (resultado)
                        MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error al guardar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // Modificar registro existente
                {
                    obj.Idempresa = Idempresa; // Usar el ID para modificar
                    resultado = L_Titular.Instancia.Modificar(obj);
                    if (resultado)
                        MessageBox.Show("Registro modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error al modificar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar o modificar tbtitular: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNuevo_Load(object sender, EventArgs e)
        {
            // Si hay un ID, se trata de una modificación
            if (!string.IsNullOrEmpty(Idempresa))
            {
                txtIdempresa.Text = Idempresa;
                txtEmpresa.Text = Empresa;
                txtIdentificador.Text = Identificador;
                txtDomiciliolegal.Text = Domiciliolegal;
                txtDistrito.Text = Distrito;
                txtProvincia.Text = Provincia;
                txtDepartamento.Text = Departamento;
                txtRuc.Text = Ruc;
                txtTelefono.Text = Telefono;
                txtCorreo.Text = Correo;
                txtRepresentante.Text = Representante;
                txtDni.Text = Dni;
                txtLlama1.Text = Llama1;
                txtLlama2.Text = Llama2;
                txtLlama3.Text = Llama3;
                txtComentarios.Text = Comentarios;
            }

            // Desactivar el campo ID para evitar edición
            txtIdempresa.ReadOnly = true;
        }

        private void btnAlmacenar_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = new M_Titular
                {
                    Empresa = txtEmpresa.Text,
                    Identificador = txtIdentificador.Text,
                    Domiciliolegal = txtDomiciliolegal.Text,
                    Distrito = txtDistrito.Text,
                    Provincia = txtProvincia.Text,
                    Departamento = txtDepartamento.Text,
                    Ruc = txtRuc.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    Representante = txtRepresentante.Text,
                    Dni = txtDni.Text,
                    Llama1 = txtLlama1.Text,
                    Llama2 = txtLlama2.Text,
                    Llama3 = txtLlama3.Text,
                    Comentarios = txtComentarios.Text
                };

                bool resultado;

                if (string.IsNullOrEmpty(Idempresa)) // Si no hay ID, es un nuevo registro
                {
                    resultado = L_Titular.Instancia.Guardar(obj); // Llama a Guardar
                    if (resultado)
                        MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Si hay ID, es una modificación
                {
                    obj.Idempresa = Idempresa; // Usar el ID para modificar
                    resultado = L_Titular.Instancia.Modificar(obj); // Llama a Modificar
                    if (resultado)
                        MessageBox.Show("Registro modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close(); // Cierra el formulario después de guardar o modificar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar o modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
