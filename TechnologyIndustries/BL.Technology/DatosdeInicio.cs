using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Technology
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            //TIPOS
            var tipo1 = new Tipo();
            tipo1.Descripcion = "Telefonos";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Tablets";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Laptops";
            contexto.Tipos.Add(tipo3);

            var tipo4 = new Tipo();
            tipo4.Descripcion = "Accesorios de sonido";
            contexto.Tipos.Add(tipo4);

            //CLASIFICACIONES
            var clasificacion1 = new Clasificacion();
            clasificacion1.Descripcion = "Gama Baja";
            contexto.Clasificaciones.Add(clasificacion1);

            var clasificacion2 = new Clasificacion();
            clasificacion2.Descripcion = "Gama Media";
            contexto.Clasificaciones.Add(clasificacion2);

            var clasificacion3 = new Clasificacion();
            clasificacion3.Descripcion = "Gama Alta";
            contexto.Clasificaciones.Add(clasificacion3);

            var clasificacion4 = new Clasificacion();
            clasificacion4.Descripcion = "Otra";
            contexto.Clasificaciones.Add(clasificacion4);

            //UBICACIONES
            var ubicacion1 = new Ubicacion();
            ubicacion1.Descripcion = "TGU";
            contexto.Ubicaciones.Add(ubicacion1);

            var ubicacion2 = new Ubicacion();
            ubicacion2.Descripcion = "SPS";
            contexto.Ubicaciones.Add(ubicacion2);

            var ubicacion3 = new Ubicacion();
            ubicacion3.Descripcion = "PTC";
            contexto.Ubicaciones.Add(ubicacion3);

            base.Seed(contexto);
        }
    }
}
