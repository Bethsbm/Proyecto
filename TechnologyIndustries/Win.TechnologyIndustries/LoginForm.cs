using BL.Technology;
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
        SeguridadBL _seguridad;

        public LoginForm()
        {
            InitializeComponent();

            _seguridad = new SeguridadBL();
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
            Login();
        }

        private void Login()
        {

            string usuario = textBoxUsuario.Text;
            string password = textBoxPassword.Text;

            buttonAceptar.Enabled = false;
            buttonAceptar.Text = "Verificando...";
            Application.DoEvents();

            var resultado = _seguridad.Autorizar(usuario, password);

            if (resultado != null)
            {
                Utilidades.nombreUsuario = resultado.Nombre;

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

        private void textBoxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && textBoxUsuario.Text != "")
            {

                textBoxPassword.Focus();
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && textBoxUsuario.Text != "" && textBoxPassword.Text != "")
            {

                Login();
            }
        }
    }
}
