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
            string _sql = "INSERT INTO VENDEDOR (CODVEND, NOMBRE, ESTADO) VALUES (@CodVend, @Nombre, @Estado)";

            using (var cmd = new SqlCommand(_sql, conn.Conexion))
            {
                cmd.Parameters.AddWithValue("@CodVend", vendedor.CodVend.Trim());
                cmd.Parameters.AddWithValue("@Nombre", vendedor.Nombre.Trim());
                cmd.Parameters.AddWithValue("@Estado", vendedor.Estado == "on" ? "activo" : "inactivo");

                conn.AbrirConexion();
                int filas = cmd.ExecuteNonQuery();
                conn.CerrarConexion();

                return filas == 1;
            }
        }
        public void AgregarReemplazo(String cod_reemplazo, String cod_Vendedor)
        {
            
            conn.AbrirConexion();

            string _actualizar_usuarios_asignados = "update CLIENTE set VENDEDOR = @cod_reemplazo where VENDEDOR = @cod_Vendedor;";

            using (var cmd = new SqlCommand(_actualizar_usuarios_asignados, conn.Conexion))
            {
                cmd.Parameters.AddWithValue("@cod_reemplazo", cod_reemplazo.Trim());
                cmd.Parameters.AddWithValue("@cod_Vendedor", cod_Vendedor.Trim());
                int filasAfectadas1 = cmd.ExecuteNonQuery();
            }

            string _actualizar_estado_vendedor = "update VENDEDOR set ESTADO = 'inactivo' where CODVEND = @cod_Vendedor;";
            using (var cmd = new SqlCommand(_actualizar_estado_vendedor, conn.Conexion))
            {
                cmd.Parameters.AddWithValue("@cod_Vendedor", cod_Vendedor.Trim());
                int filasAfectadas2 = cmd.ExecuteNonQuery();
            }

            conn.CerrarConexion();
            
        }
        public bool Editar(Vendedor vendedor)
        {
            string _sql = "UPDATE dbo.VENDEDOR SET NOMBRE = @Nombre, ESTADO = @Estado WHERE CODVEND = @CodVend;";

            using (var cmd = new SqlCommand(_sql, conn.Conexion))
            {
                cmd.Parameters.AddWithValue("@Nombre", vendedor.Nombre.Trim());
                cmd.Parameters.AddWithValue("@Estado", vendedor.Estado == "on" ? "activo" : "inactivo");
                cmd.Parameters.AddWithValue("@CodVend", vendedor.CodVend.Trim());

                conn.AbrirConexion();
                int filas = cmd.ExecuteNonQuery();
                conn.CerrarConexion();

                return filas == 1;
            }
        }

        public List<Vendedor> GetVendedores()
        {
            List<Vendedor> lista = new List<Vendedor>();

            string _sql = "SELECT * FROM VENDEDOR";

            using (var cmd = new SqlCommand(_sql, conn.Conexion))
            {
                conn.AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vendedor vendedor = new Vendedor
                        {
                            CodVend = reader["CODVEND"].ToString(),
                            Nombre = reader["NOMBRE"].ToString(),
                            Estado = reader["ESTADO"].ToString()
                        };
                        lista.Add(vendedor);
                    }
                }
                conn.CerrarConexion();
            }

            return lista;
        }
    }
}