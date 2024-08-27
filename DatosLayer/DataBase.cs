using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Clase que maneja la configuración de la cadena de conexión y la obtención de conexiones a la base de datos
    public class DataBase
    {
        // Propiedad estática que define el tiempo de espera para las conexiones a la base de datos (en segundos)
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática que define el nombre de la aplicación para las conexiones a la base de datos
        public static string ApplicationName { get; set; }

        // Propiedad estática que obtiene la cadena de conexión a la base de datos configurada
        public static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión desde el archivo de configuración (app.config o web.config)
                string CadenaConexion = ConfigurationManager.ConnectionStrings["NWConnection"].ConnectionString;

                // Crea un SqlConnectionStringBuilder para construir y modificar la cadena de conexión
                SqlConnectionStringBuilder conexionBuilder = new SqlConnectionStringBuilder(CadenaConexion);

                // Configura el nombre de la aplicación en la cadena de conexión, si se ha especificado
                conexionBuilder.ApplicationName = ApplicationName ?? conexionBuilder.ApplicationName;

                // Configura el tiempo de espera para la conexión, si se ha especificado un valor mayor que 0
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Retorna la cadena de conexión construida como una cadena de texto
                return conexionBuilder.ToString();
            }
        }

        // Método estático que obtiene una conexión abierta a la base de datos
        public static SqlConnection GetSqlConnection()
        {
            // Crea una nueva instancia de SqlConnection usando la cadena de conexión configurada
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión a la base de datos
            conexion.Open();

            // Retorna la conexión abierta
            return conexion;
        }
    }

}
