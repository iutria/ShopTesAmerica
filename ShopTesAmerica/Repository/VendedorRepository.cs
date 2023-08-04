using ShopTesAmerica.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopTesAmerica.Repository
{
    public class VendedorRepository
    {
        readonly private ConeccionDB conn = null;
        public VendedorRepository()
        {
            conn = new ConeccionDB();
        }

        public bool Agregar(Vendedor vendedor)
        {
            string _sql = string.Format(
                "insert into VENDEDOR " +
                "(CODVEND, NOMBRE, ESTADO) " +
                "values ('{0}', '{1}', '{2}')",
                vendedor.CodVend.Trim(),
                vendedor.Nombre.Trim(),
                vendedor.Estado=="on"?"activo":"inactivo"
            );
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public bool Editar(Vendedor vendedor)
        {
            string _sql = string.Format(
                "update dbo.VENDEDOR SET NOMBRE = '{1}', ESTADO = '{2}' WHERE CODVEND = '{0}';",
                vendedor.CodVend.Trim(),
                vendedor.Nombre.Trim(),
                vendedor.Estado == "on" ? "activo" : "inactivo"
            );
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public List<Vendedor> GetVendedores()
        {
            string _sql = "select * from VENDEDOR";
            System.Data.DataTable tabla = new DataTable("VENDEDOR");
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conn.Conexion);

            adapter.Fill(tabla);

            List<Vendedor> lista = new List<Vendedor>();

            foreach (var fila in tabla.Rows)
            {
                lista.Add(new Vendedor((DataRow)fila));
            }
            return lista;
        }
    }
}