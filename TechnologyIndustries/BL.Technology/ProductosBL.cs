using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Technology
{
    public class ProductosBL
    {
       public BindingList<Producto> ListadeProductos { get; set; }

        public ProductosBL()
        {
            ListadeProductos = new BindingList<Producto>();

            var Producto1 = new Producto();

            Producto1.ID = 1;
            Producto1.Descripción = "Lenovo Tab P11 Pro";
            Producto1.Precio = 19500;
            Producto1.Stock = 11;
            Producto1.Ubicación = "A-01";
            Producto1.Activo = true;

            ListadeProductos.Add(Producto1);

            var Producto2 = new Producto();

            Producto2.ID = 2;
            Producto2.Descripción = "Huawei MatePad T8";
            Producto2.Precio = 12000;
            Producto2.Stock = 15;
            Producto2.Ubicación = "A-02";
            Producto2.Activo = true;

            ListadeProductos.Add(Producto2);

            var Producto3 = new Producto();

            Producto3.ID = 3;
            Producto3.Descripción = "Xiaomi Redmi 9A";
            Producto3.Precio = 10000;
            Producto3.Stock = 19;
            Producto3.Ubicación = "B-01";
            Producto3.Activo = true;

            ListadeProductos.Add(Producto3);

            var Producto4 = new Producto();

            Producto4.ID = 4;
            Producto4.Descripción = "Apple iPad Mini 7'";
            Producto4.Precio = 23000;
            Producto4.Stock = 10;
            Producto4.Ubicación = "A-03";
            Producto4.Activo = true;

            ListadeProductos.Add(Producto4);

            var Producto5 = new Producto();

            Producto5.ID = 5;
            Producto5.Descripción = "Motorola G100";
            Producto5.Precio = 8000;
            Producto5.Stock = 7;
            Producto5.Ubicación = "B-02";
            Producto5.Activo = true;

            ListadeProductos.Add(Producto5);

            var Producto6 = new Producto();

            Producto6.ID = 3;
            Producto6.Descripción = "Huawei P30 Lite";
            Producto6.Precio = 9500;
            Producto6.Stock = 12;
            Producto6.Ubicación = "B-03";
            Producto6.Activo = true;

            ListadeProductos.Add(Producto6);
        }

        public BindingList<Producto> ObtenerProducto()
        {
            return ListadeProductos;
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
}
