using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Technology
{
    public class SeguridadBL
    {
        public bool Autorizar(string usuario, string password)
        {
            if (usuario == "JulioRojas" && password == "20192002031")
            {
                return true;
            }
            else if (usuario == "MaritzaSosa" && password == "20166130012")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
