using BL.Technology;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.TechnologyIndustries
{
    public partial class IngresoInventarioForm : Form
    {
        ProductosBL _productos;
        TiposBL _tiposBL;
        ClasificacionesBL _clasificacionesBL;
        UbicacionesBL _ubicacionesBL;

        public IngresoInventarioForm()
        {
            InitializeComponent();

            _productos = new ProductosBL();
            listadeProductosBindingSource.DataSource = _productos.ObtenerProducto();

            _tiposBL = new TiposBL();
            listaTiposBindingSource.DataSource = _tiposBL.ObtenerTipos();

            _clasificacionesBL = new ClasificacionesBL();
            listaClasificacionesBindingSource.DataSource = _clasificacionesBL.ObtenerClasificaciones();

            _ubicacionesBL = new UbicacionesBL();
            listaUbicacionesBindingSource.DataSource = _ubicacionesBL.ObtenerUbicaciones();
        }

        private void IngresoInventarioForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listadeProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listadeProductosBindingSource.EndEdit();
            var producto = (Producto)listadeProductosBindingSource.Current;

            if (fotoPictureBox.Image != null)
            {
                producto.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                producto.Foto = null;
            }

            var resultado = _productos.GuardarProducto(producto);

            if (resultado.Exitoso == true)
            {
                listadeProductosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("¡Producto guardado exitosamente!");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            listadeProductosBindingSource.MoveLast();
            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (iDTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Seguro que desea eliminar este registro?", "ALERTA", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(iDTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {
            var resultado = _productos.EliminarProducto(id);

            if (resultado == true)
            {
                listadeProductosBindingSource.ResetBindings(false);
                MessageBox.Show("¡Producto eliminado exitosamente!");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar el producto");
            }
        }

        private void iDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _productos.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var producto = (Producto)listadeProductosBindingSource.Current;

            if (producto != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }
            }
            else
            {
                MessageBox.Show("Recuerde crear un producto antes de asignarle una imagen");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            string buscar = textBox1.Text;

        
            if (buscar == "")
            {
                listadeProductosBindingSource.DataSource = _productos.ObtenerProducto();
            }
            else
            {
                listadeProductosBindingSource.DataSource = _productos.ObtenerProducto(buscar);
            }

            listadeProductosBindingSource.ResetBindings(false);
        }
    }
}
