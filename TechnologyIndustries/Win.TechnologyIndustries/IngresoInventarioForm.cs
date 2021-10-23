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
    public partial class IngresoInventarioForm : Form
    {
        ProductosBL _productos;
        public IngresoInventarioForm()
        {
            InitializeComponent();

            _productos = new ProductosBL();
            listadeProductosBindingSource.DataSource = _productos.ObtenerProducto();
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
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }
    }
}
