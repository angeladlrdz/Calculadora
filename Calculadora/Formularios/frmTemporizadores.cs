using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic; //Para usar InputBox
using System.Media; //Para traer el audio
using CSCore.SoundOut; //Libreria descargada de paquetes nuGet

namespace Calculadora.Formularios
{
    public partial class frmTemporizadores : Form
    {
        string alarma1 = "";
        public frmTemporizadores()
        {
            InitializeComponent();
        }

        private void tmrHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString(); //Para poner la hora en la label short(hora) long(agrega los segundos)
            if(lblHora.Text == alarma1)
            {
                SoundPlayer player = new SoundPlayer(@"C:\Users\angel\source\repos\Calculadora\Calculadora\Sonidos\dragon-studio-rooster-call-364474.wav");
                player.Play();  
            }
        }

        private void alarma1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alarma1 = Interaction.InputBox("Ingrese la hora: ", "Sistema", "00:00:00 x. x."); //Es un cuadro de texto
        }
    }
}
