using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopTesAmerica.Models
{
    public class Producto
    {
        public String CodProd { get; set; }
        public String Nombre { get; set; }
        public String Familia { get; set; }
        public int Precio { get; set; }
        public Producto()
        {

        }
        public Producto(DataRow map)
        {
            this.CodProd = (string)map[0];
            this.Nombre = (string)map[1];
            this.Familia = (string)map[2];
            this.Precio = int.Parse((string)map[3].ToString());
        }
    }
}