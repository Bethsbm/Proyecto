using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Technology
{
    public class UbicacionesBL
    {
        Contexto _contexto;

        public BindingList<Ubicacion> ListaUbicaciones { get; set; }

        public UbicacionesBL()
        {
            _contexto = new Contexto();
            ListaUbicaciones = new BindingList<Ubicacion>();
        }

        public BindingList<Ubicacion> ObtenerUbicaciones()
        {
            _contexto.Ubicaciones.Load();
            ListaUbicaciones = _contexto.Ubicaciones.Local.ToBindingList();

            return ListaUbicaciones;
        }
    }

    public class Ubicacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
