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

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ofdEditor.ShowDialog() == DialogResult.OK)//Open file dialog //Si le pico al boton ok va a hacer..
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
            if(saved == false)
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
    }
}
