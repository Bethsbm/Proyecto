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
    public partial class MenuPrincipalForm : Form
    {
        public MenuPrincipalForm()
        {
            InitializeComponent();
            Maximizar();
        }

        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ingresoInventario = new IngresoInventarioForm();
            AbrirFormulario<IngresoInventarioForm>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var carteraClientes = new CarteraClientesForm();
            AbrirFormulario<CarteraClientesForm>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var FacturaForm = new FacturaForm();
            AbrirFormulario<FacturaForm>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var reporteProductos = new ReporteProductosForm();
            AbrirFormulario<ReporteProductosForm>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var reporteClientes = new ReporteClientesForm();
            AbrirFormulario<ReporteClientesForm>();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var reporteVentas = new ReporteVentasForm();
            AbrirFormulario<ReporteVentasForm>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            Maximizar();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void IniciarSesion()
        {
            var loginForm = new LoginForm();
            loginForm.ShowDialog();

            toolStripStatusLabel9.Text = Utilidades.nombreUsuario;
            toolStripStatusLabel4.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel8.Text = DateTime.Now.ToLongTimeString();
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }

            else
            {
                formulario.BringToFront();
            }
        }

        private void Maximizar()
        {
            int lx = this.Location.X;
            int ly = this.Location.Y;
            int sw = this.Size.Width;
            int sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
    }
}
