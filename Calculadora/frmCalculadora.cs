using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void txtVariableA_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //Uso del try-catch
            try
            {
                //Declarar de tipo int dos variables
                int a = 0, b = 0, resultado = 0;

                //Convertir de String a int con parse y con convert
                a = Convert.ToInt32(txtVariableA.Text);
                b = int.Parse(txtVariableB.Text);

                resultado = a + b;

                //Mostrar el resultado, Nombre del recuadro, el boton que tiene el recuadro, El sonido de que sale el recuadro
                MessageBox.Show("El resultado es: " + resultado.ToString(), "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conversion de datos", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            txtVariableA.Text = "";
            txtVariableB.Clear();
            txtVariableA.Focus(); //Para que el cursos se vaya directamente al txtVariableA
        }
    }
}
