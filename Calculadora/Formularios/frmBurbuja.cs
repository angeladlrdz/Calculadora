using Calculadora.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmBurbuja : Form
    {
        public frmBurbuja()
        {
            InitializeComponent();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            Ordenamientos ordenamiento = new Ordenamientos();
            int[] ordenado = new int [dgvDesordenado.RowCount - 1];

            for (int i = 0; i < dgvDesordenado.RowCount - 1; i++)
            {
                ordenado[i] = Convert.ToInt32(dgvDesordenado.Rows[i].Cells[0].Value);
            }

            ordenado = ordenamiento.Burbuja(ordenado);

            dgvOrdenado.DataSource = ordenado; //Define el tamaño de las filas del dgv de acuerdo al tamaño del arreglo

            for(int i = 0; i < ordenado.Length; i++) 
            {
                dgvOrdenado.Rows[i].Cells[0].Value = ordenado[i]; //Inserta los datos ya ordenados
            }
        }
    }
}
