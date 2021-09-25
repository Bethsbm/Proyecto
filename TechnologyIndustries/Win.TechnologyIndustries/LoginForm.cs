using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.TechnologyIndustries
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text;
            string password = textBoxPassword.Text;

            if (usuario == "JulioRojas" && password == "20192002031")
            {
                this.Close();
            }
            else if (usuario == "MaritzaSosa" && password == "20166130012")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("¡No hay problema! Solo intenta recordarla.");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
