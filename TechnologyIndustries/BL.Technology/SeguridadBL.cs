using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Technology
{
    public class SeguridadBL
    {
        Contexto _contexto;

        public SeguridadBL()
        {
            _contexto = new Contexto();
        }

        public Usuario Autorizar(string usuario, string password)
        {
            var usuarios = _contexto.Usuarios.ToList();

            foreach (var usuarioDB in usuarios)
            {
                if (usuario == usuarioDB.Nombre && password == usuarioDB.Password)
                {
                    return usuarioDB;
                }
            }

            return null;
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
    }
}
