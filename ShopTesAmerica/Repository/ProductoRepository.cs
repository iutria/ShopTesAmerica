using ShopTesAmerica.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Collections;

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
            string query = "INSERT INTO PRODUCTO (CODPROD, NOMBRE, FAMILIA, PRECIO) " +
                   "VALUES (@CodProd, @Nombre, @Familia, @Precio)";
            using (SqlCommand command = new SqlCommand(query, conn.Conexion))
            {
                command.Parameters.AddWithValue("@CodProd", producto.CodProd.Trim());
                command.Parameters.AddWithValue("@Nombre", producto.Nombre.Trim());
                command.Parameters.AddWithValue("@Familia", producto.Familia.Trim());
                command.Parameters.AddWithValue("@Precio", producto.Precio);

                conn.AbrirConexion();
                int filasAfectadas = command.ExecuteNonQuery();
                conn.CerrarConexion();

                return filasAfectadas == 1;
            }
        }
        public bool IncrementarPrecios()
        {
            string _sql = "UPDATE producto "+
                "SET precio = CASE " +
                    "WHEN familia = 'Hardware' THEN precio * 1.10 " +
                    "WHEN familia = 'Software' THEN precio * 1.08 " +
                    "WHEN familia = 'Servicios' THEN precio * 1.06 " +
                    "ELSE precio "+
                "END";
            using (SqlCommand command = new SqlCommand(_sql, conn.Conexion))
            {
                conn.AbrirConexion();
                command.ExecuteNonQuery();
                conn.CerrarConexion();

                return true;
            }
        }
        public bool Editar(Producto producto)
        {
            string query = "UPDATE dbo.PRODUCTO SET NOMBRE = @Nombre, FAMILIA = @Familia, PRECIO = @Precio WHERE CODPROD = @CodProd;";

            using (SqlCommand command = new SqlCommand(query, conn.Conexion))
            {
                command.Parameters.AddWithValue("@Nombre", producto.Nombre.Trim());
                command.Parameters.AddWithValue("@Familia", producto.Familia.Trim());
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@CodProd", producto.CodProd.Trim());

                conn.AbrirConexion();
                int filasAfectadas = command.ExecuteNonQuery();
                conn.CerrarConexion();

                return filasAfectadas == 1;
            }
        }
        public List<Producto> GetProductos()
        {
            List<Producto> lista = new List<Producto>();

            string query = "SELECT * FROM PRODUCTO";

            using (SqlCommand command = new SqlCommand(query, conn.Conexion))
            {
                conn.AbrirConexion();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            CodProd = reader["CODPROD"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Familia = reader["Familia"].ToString(),
                            Precio = int.Parse(reader["Precio"].ToString())
                        };
                        lista.Add(producto);
                    }
                }
                conn.CerrarConexion();
            }               

            return lista;
        }
    }
}