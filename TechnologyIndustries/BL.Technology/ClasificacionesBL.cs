using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Technology
{
    public class ClasificacionesBL
    {
        Contexto _contexto;

        public BindingList<Clasificacion> ListaClasificaciones { get; set; }

        public ClasificacionesBL()
        {
            _contexto = new Contexto();
            ListaClasificaciones = new BindingList<Clasificacion>();
        }

        public BindingList<Clasificacion> ObtenerClasificaciones()
        {
            _contexto.Clasificaciones.Load();
            ListaClasificaciones = _contexto.Clasificaciones.Local.ToBindingList();

            return ListaClasificaciones;
        }
    }

    public class Clasificacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
