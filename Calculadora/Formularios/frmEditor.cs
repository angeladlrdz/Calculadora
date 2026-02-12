using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Calculadora
{
    public partial class frmEditor : Form
    {
        public frmEditor()
        {
            InitializeComponent();
        }

        public bool saved = false; //Para saber si lo guardo por primera vez o si sobreescribo si es ya estaba guardado anteriormente
        public string path = "";
        public string texto;

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdEditor.ShowDialog() == DialogResult.OK)//Open file dialog //Si le pico al boton ok va a hacer..
            {
                if (File.Exists(ofdEditor.FileName)) //Si la ruta que estoy seleccionando existe...
                {
                    rtbEditor.Text = File.ReadAllText(ofdEditor.FileName); //Voy a leer el archivo
                    //Si se usa el using StreamReader lee linea por linea hasta que encuentra un salto de linea
                }
            }

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved == false)
            {
                Guardar();
                saved = true;
            }
            else
            {
                using (StreamWriter archivo = new StreamWriter(path)) //Voy a escribir un archivo //(la ruta del archivo que voy a guardar)
                {
                    archivo.Write(rtbEditor.Text); //Le voy a mandar lo que esta escrito en el richTextBox
                }
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.Clear();  //Para que se limpie
            path = "";
            saved = false;
        }

        //Metodo Guardar, que es el guardar como
        private void Guardar()
        {
            if (sfdEditor.ShowDialog() == DialogResult.OK) //Save file dialog //Si le pico al boton ok va a hacer..
            {
                path = sfdEditor.FileName; // la ubicacion de cuando lo guardo por primera vez, para que no se destruya lo pongo en esa variable
                using (StreamWriter archivo = new StreamWriter(path)) //Voy a escribir un archivo //(la ruta del archivo que voy a guardar)
                {
                    archivo.Write(rtbEditor.Text); //Le voy a mandar lo que esta escrito en el richTextBox
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtbEditor_TextChanged(object sender, EventArgs e)
        {
            //Cuando cambie el texto, es el evento
            texto = rtbEditor.Text;
            //El tabulador se puede bloquear desde las propiedades o con codigo '\t'
            string[] palabras = texto.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            tssStatus.Text = palabras.Length.ToString() + " Palabras";
        }

        private void tssStatus_Click(object sender, EventArgs e)
        {
            string[] palabras = texto.Split(new char[] { ' ', '\n', '\r', '\t' }, 
               StringSplitOptions.RemoveEmptyEntries);
            string[] parrafos = texto.Split(new char[] { '\n' },
               StringSplitOptions.RemoveEmptyEntries);
            //Numero de palabras, numero de letras con espacio, numero de parrafos
            MessageBox.Show("Estadisticas:\n\nPalabras: " + palabras.Length.ToString() + 
                "\nLetras: " + texto.Length.ToString() + 
                "\nParrafos: "+ parrafos.Length.ToString(), "Contador de Palabras");
        }
    }
}
