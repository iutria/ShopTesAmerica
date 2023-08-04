using ShopTesAmerica.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopTesAmerica.Repository
{
    public class ProductoRepository
    {
        readonly private ConeccionDB conn = null;
        public ProductoRepository()
        {
            conn = new ConeccionDB();
        }

        public bool Agregar(Producto producto)
        {
            string _sql = string.Format(
                "insert into PRODUCTO " +
                "(CODPROD, NOMBRE, FAMILIA, PRECIO) " +
                "values ('{0}', '{1}', '{2}', {3})",
                producto.CodProd.Trim(),
                producto.Nombre.Trim(),
                producto.Familia.Trim(),
                producto.Precio
            );
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public bool Editar(Producto producto)
        {
            string _sql = string.Format(
                "update dbo.PRODUCTO SET NOMBRE = '{1}', FAMILIA = '{2}', PRECIO = {3} WHERE CODPROD = '{0}';",
                producto.CodProd.Trim(),
                producto.Nombre.Trim(),
                producto.Familia.Trim(),
                producto.Precio
            );
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public List<Producto> GetProductos()
        {
            string _sql = "select * from PRODUCTO";
            System.Data.DataTable tabla = new DataTable("PRODUCTO");
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conn.Conexion);

            adapter.Fill(tabla);

            List<Producto> lista = new List<Producto>();

            foreach (var fila in tabla.Rows)
            {
                lista.Add(new Producto((DataRow)fila));
            }
            return lista;
        }
    }
}