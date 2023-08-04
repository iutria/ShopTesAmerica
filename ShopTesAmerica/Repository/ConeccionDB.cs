using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopTesAmerica.Repository
{
    public class ConeccionDB
    {
        public SqlConnection Conexion;
        public ConeccionDB()
        {
            Conexion = new SqlConnection("Server=IUTRIA\\SQLEXPRESS01;DataBase=BDTIENDATESAMERICA;Integrated Security=true");
        }
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}