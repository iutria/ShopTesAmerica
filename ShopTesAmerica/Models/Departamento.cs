using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTesAmerica.Models
{
    public class Departamento
    {
        public String CodDep { get; set; }
        public String Nombre { get; set; }

        public List<Ciudad> Ciudades { get; set; }
    }
}