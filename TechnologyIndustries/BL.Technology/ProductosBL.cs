using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Technology
{
    public class ProductosBL
    {
        Contexto _contexto;
       public BindingList<Producto> ListadeProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new BindingList<Producto>();

        }

        public BindingList<Producto> ObtenerProducto()
        {
            _contexto.Productos.Load();
            ListadeProductos = _contexto.Productos.Local.ToBindingList();

            return ListadeProductos;
        }

        public Resultado GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();
            ListadeProductos.Add(nuevoProducto);
        }

        public bool EliminarProducto(int id)
        {
            foreach (var producto in ListadeProductos)
            {
                if (producto.ID == id)
                {
                    ListadeProductos.Remove(producto);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(producto.Ubicación) == true)
            {
                resultado.Mensaje = "Ingrese la ubicación del producto";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(producto.Descripción) == true)
            {
                resultado.Mensaje = "Ingrese una descripción";
                resultado.Exitoso = false;
            }

            if (producto.Stock < 0)
            {
                resultado.Mensaje = "El stock debe ser mayor que cero";
                resultado.Exitoso = false;
            }

            if (producto.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor que cero";
                resultado.Exitoso = false;
            }

            return resultado;
        }
    }

    public class Producto
    {
        public int ID { get; set; }
        public string Descripción { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string Ubicación { get; set; }
        public bool Activo { get; set; }

    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
