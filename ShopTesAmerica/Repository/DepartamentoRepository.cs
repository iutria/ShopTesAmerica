using ShopTesAmerica.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopTesAmerica.Repository
{
    public class DepartamentoRepository
    {
        readonly private ConeccionDB conn = null;
        public DepartamentoRepository()
        {
            conn = new ConeccionDB();
        }

        public bool AgregarDepartamento(Departamento departamento)
        {
            string _sql = "INSERT INTO DEPARTAMENTO (CODDEP, NOMBRE) VALUES (@CodDep, @Nombre)";

            departamento.CodDep = GenerarCodigo();

            using (var cmd = new SqlCommand(_sql, conn.Conexion))
            {
                cmd.Parameters.AddWithValue("@CodDep", departamento.CodDep.Trim());
                cmd.Parameters.AddWithValue("@Nombre", departamento.Nombre.Trim());

                conn.AbrirConexion();
                int filas = cmd.ExecuteNonQuery();
                conn.CerrarConexion();

                return filas == 1;
            }
        }
        public bool AgregarCiudad(Ciudad ciudad)
        {
            string _sql = "INSERT INTO CIUDAD (CODCIU, NOMBRE, DEPARTAMENTO) VALUES (@CodCiu, @Nombre, @Departamento)";

            ciudad.CodCiu = GenerarCodigo();

            using (var cmd = new SqlCommand(_sql, conn.Conexion))
            {
                cmd.Parameters.AddWithValue("@CodCiu", ciudad.CodCiu.Trim());
                cmd.Parameters.AddWithValue("@Nombre", ciudad.Nombre.Trim());
                cmd.Parameters.AddWithValue("@Departamento", ciudad.Departamento.Trim());

                conn.AbrirConexion();
                int filas = cmd.ExecuteNonQuery();
                conn.CerrarConexion();

                return filas == 1;
            }
        }
        public List<Departamento> GetDepartamentos() {
            List<Departamento> departamentos = new List<Departamento>();

            string queryDepartamentos = "SELECT * FROM DEPARTAMENTO";
            string queryCiudades = "SELECT * FROM CIUDADES";

            conn.AbrirConexion();

            // Obtener departamentos
            using (SqlCommand commandDepartamentos = new SqlCommand(queryDepartamentos, conn.Conexion))
            {
                using (SqlDataReader readerDepartamentos = commandDepartamentos.ExecuteReader())
                {
                    while (readerDepartamentos.Read())
                    {
                        Departamento departamento = new Departamento
                        {
                            CodDep = readerDepartamentos["CodDep"].ToString(),
                            Nombre = readerDepartamentos["Nombre"].ToString(),
                            Ciudades = new List<Ciudad>()
                        };
                        departamentos.Add(departamento);
                    }
                }
            }

            // Obtener ciudades
            using (SqlCommand commandCiudades = new SqlCommand(queryCiudades, conn.Conexion))
            {
                using (SqlDataReader readerCiudades = commandCiudades.ExecuteReader())
                {
                    while (readerCiudades.Read())
                    {
                        Ciudad ciudad = new Ciudad
                        {
                            CodCiu = readerCiudades["CodCiu"].ToString(),
                            Nombre = readerCiudades["Nombre"].ToString(),
                            Departamento = readerCiudades["Departamento"].ToString()
                        };

                        // Asociar la ciudad al departamento correspondiente
                        Departamento departamento = departamentos.FirstOrDefault(d => d.CodDep == ciudad.Departamento);
                        departamento?.Ciudades.Add(ciudad);
                    }
                }
            }

            conn.CerrarConexion();

            return departamentos;

        }
        private static string GenerarCodigo()
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}