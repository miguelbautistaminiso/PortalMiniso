using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalMiniso
{
    public class Connections
    {
        public string cadenaConexion()
        {
            string dominio = ConfigurationManager.ConnectionStrings["ip"].ConnectionString;
            string nombreBase = ConfigurationManager.ConnectionStrings["base"].ConnectionString;
            string usuario = ConfigurationManager.ConnectionStrings["usuario"].ConnectionString;
            string contrasena = ConfigurationManager.ConnectionStrings["contrasena"].ConnectionString;
            //string cadenaConexion = @"Data Source=" + dominio + @";Database=" + nombreBase + @";User ID=" + usuario + @";Password=" + contrasena + @"";
            string cadenaConexion = @"Server = MNSO-121\SQLEXPRESS; Database=" + nombreBase + @"; User ID=" + usuario + @";Password=" + contrasena + @"";

            return cadenaConexion;
        }

        public string ejecutarQuery(string usuario)
        {

            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader sqlDataReader;

            Console.WriteLine($"Conectando con base de datos...");
            cnn = new SqlConnection(cadenaConexion());

            string obtUsuario = string.Empty;
            try
            {
                cnn.Open();
                Console.WriteLine("Conexion abierta.");
                Console.WriteLine("Obteniendo datos...");

                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = obtenerQuery(usuario);

                command = new SqlCommand(sql, cnn);
                sqlDataReader = command.ExecuteReader();



                while (sqlDataReader.Read())
                {
                    obtUsuario = sqlDataReader.GetString(1);
                }

                Console.WriteLine("Cerrando conexion...");
                cnn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obtUsuario;
        }

        public string obtenerQuery(string usuario)
        {
            string query = @"
             select * from EMPLOYEE where EMPLOYEE_NO = '" + usuario + @"';
            ";
                return query;
        }

    }
}