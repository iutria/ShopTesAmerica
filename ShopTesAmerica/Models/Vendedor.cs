using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopTesAmerica.Models
{
    public class Vendedor
    {
        public String CodVend { get; set; }
        public String Nombre { get; set; }
        public String Estado { get; set; }
        public Vendedor()
        {

        }
        public Vendedor(DataRow map)
        {
            this.CodVend = (string)map[0];
            this.Nombre = (string)map[1];
            this.Estado = (string)map[2];
        }

        override
        public String ToString()
        {
            return "CodVend: " + CodVend + " Nombre: " + Nombre + " Estado:" + Estado;
        }
    }
}