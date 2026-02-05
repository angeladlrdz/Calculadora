using Calculadora.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculadora.Formularios
{
    public partial class frmRegistro : Form
    {
        List<Persona> persona = new List<Persona>(); //Inicializar lista
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            persona.Add(new Persona()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Fecha = dtpFecha.Value
            });
            MessageBox.Show("Datos Registrados", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Para poner los datos registrados en la dgv en mostrar, el metodo es selectedIndexChanged y se puso en mostrar
            if (tabControl1.SelectedIndex == 1)
            {
                dgvPeronas.DataSource = null;
                dgvPeronas.DataSource = persona;
            }
        }
    }
}
