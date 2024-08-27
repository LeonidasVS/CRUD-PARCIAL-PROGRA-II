using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class PersonaRepository
    {
        // Método que obtiene una lista de objetos Person desde la base de datos
        public List<Person> ObtenerDatos()
        {
            // Establece una conexión a la base de datos usando un método de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Define una cadena SQL para seleccionar columnas específicas de la tabla Suppliers
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [SupplierID] " + "\n";         // ID del proveedor
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";        // Nombre de la empresa
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";        // Nombre del contacto
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";       // Título del contacto
                selectFrom = selectFrom + "      ,[Address] " + "\n";            // Dirección
                selectFrom = selectFrom + "      ,[City] " + "\n";               // Ciudad
                selectFrom = selectFrom + "      ,[Region] " + "\n";             // Región
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";         // Código postal
                selectFrom = selectFrom + "      ,[Country] " + "\n";            // País
                selectFrom = selectFrom + "      ,[Phone] " + "\n";              // Teléfono
                selectFrom = selectFrom + "      ,[Fax] " + "\n";                // Fax
                selectFrom = selectFrom + "      ,[HomePage] " + "\n";           // Página de inicio
                selectFrom = selectFrom + "  FROM [dbo].[Suppliers]";             // De la tabla Suppliers

                // Crea un objeto SqlCommand para ejecutar la consulta SQL
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    // Ejecuta el comando y obtiene un SqlDataReader para leer los datos
                    SqlDataReader reader = comando.ExecuteReader();
                    // Crea una lista para almacenar los objetos Person
                    List<Person> persona = new List<Person>();

                    // Lee los datos del SqlDataReader mientras haya registros disponibles
                    while (reader.Read())
                    {
                        // Convierte el registro actual en un objeto Person usando el método LeerDelDataReader
                        var person = LeerDelDataReader(reader);
                        // Agrega el objeto Person a la lista
                        persona.Add(person);
                    }
                    // Retorna la lista de objetos Person
                    return persona;
                }
            }
        }


        // Método que convierte una fila de datos de SqlDataReader en un objeto Person
        public Person LeerDelDataReader(SqlDataReader reader)
        {
            // Crea una nueva instancia del objeto Person
            Person persona = new Person();

            // Asigna el valor de SupplierID desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna 0
            persona.SupplierID = reader["SupplierID"] == DBNull.Value ? 0 : (int)reader["SupplierID"];

            // Asigna el valor de CompanyName desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (string)reader["CompanyName"];

            // Asigna el valor de ContactName desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.ContactName = reader["ContactName"] == DBNull.Value ? "" : (string)reader["ContactName"];

            // Asigna el valor de ContactTitle desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (string)reader["ContactTitle"];

            // Asigna el valor de Address desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.Address = reader["Address"] == DBNull.Value ? "" : (string)reader["Address"];

            // Asigna el valor de City desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.City = reader["City"] == DBNull.Value ? "" : (string)reader["City"];

            // Asigna el valor de Region desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.Region = reader["Region"] == DBNull.Value ? "" : (string)reader["Region"];

            // Asigna el valor de PostalCode desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (string)reader["PostalCode"];

            // Asigna el valor de Country desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.Country = reader["Country"] == DBNull.Value ? "" : (string)reader["Country"];

            // Asigna el valor de Phone desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.Phone = reader["Phone"] == DBNull.Value ? "" : (string)reader["Phone"];

            // Asigna el valor de Fax desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.Fax = reader["Fax"] == DBNull.Value ? "" : (string)reader["Fax"];

            // Asigna el valor de HomePage desde el SqlDataReader al objeto Person
            // Si el valor en la base de datos es DBNull, se asigna una cadena vacía
            persona.HomePage = reader["HomePage"] == DBNull.Value ? "" : (string)reader["HomePage"];

            // Retorna el objeto Person con los valores asignados
            return persona;
        }

        // Método que agrega un nuevo registro de persona en la base de datos
        public int añadirPersonal(Person persona)
        {
            // Establece una conexión a la base de datos usando un método de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Define la cadena SQL para insertar un nuevo registro en la tabla Suppliers
                String InsertPerson = "";
                InsertPerson = InsertPerson + "INSERT INTO [dbo].[Suppliers] " + "\n";     // Inserta en la tabla Suppliers
                InsertPerson = InsertPerson + "           ([CompanyName] " + "\n";        // Columna CompanyName
                InsertPerson = InsertPerson + "           ,[ContactName] " + "\n";        // Columna ContactName
                InsertPerson = InsertPerson + "           ,[ContactTitle] " + "\n";       // Columna ContactTitle
                InsertPerson = InsertPerson + "           ,[City] " + "\n";               // Columna City
                InsertPerson = InsertPerson + "           ,[PostalCode] " + "\n";         // Columna PostalCode
                InsertPerson = InsertPerson + "           ,[Country] " + "\n";            // Columna Country
                InsertPerson = InsertPerson + "           ,[Phone])" + "\n";              // Columna Phone
                InsertPerson = InsertPerson + "     VALUES " + "\n";                       // Especifica los valores a insertar
                InsertPerson = InsertPerson + "           (@CompanyName" + "\n";          // Valor para CompanyName
                InsertPerson = InsertPerson + "           ,@ContactName" + "\n";          // Valor para ContactName
                InsertPerson = InsertPerson + "           ,@ContactTitle" + "\n";         // Valor para ContactTitle
                InsertPerson = InsertPerson + "           ,@City" + "\n";                // Valor para City
                InsertPerson = InsertPerson + "           ,@PostalCode" + "\n";          // Valor para PostalCode
                InsertPerson = InsertPerson + "           ,@Country" + "\n";             // Valor para Country
                InsertPerson = InsertPerson + "           ,@Phone)";                    // Valor para Phone

                // Crea un objeto SqlCommand para ejecutar el comando SQL de inserción
                using (var comando = new SqlCommand(InsertPerson, conexion))
                {
                    // Establece los parámetros del comando con los valores de la persona
                    int insertados = parametrosPersonal(persona, comando);

                    // Retorna el número de registros insertados
                    return insertados;
                }
            }
        }

        // Método que asigna los valores de un objeto Person a los parámetros de un SqlCommand
        public int parametrosPersonal(Person personal, SqlCommand comando)
        {
            // Asigna el valor de CompanyName al parámetro @CompanyName del comando SQL
            comando.Parameters.AddWithValue("CompanyName", personal.CompanyName);

            // Asigna el valor de ContactName al parámetro @ContactName del comando SQL
            comando.Parameters.AddWithValue("ContactName", personal.ContactName);

            // Asigna el valor de ContactTitle al parámetro @ContactTitle del comando SQL
            comando.Parameters.AddWithValue("ContactTitle", personal.ContactTitle);

            // Asigna el valor de City al parámetro @City del comando SQL
            comando.Parameters.AddWithValue("City", personal.City);

            // Asigna el valor de PostalCode al parámetro @PostalCode del comando SQL
            comando.Parameters.AddWithValue("PostalCode", personal.PostalCode);

            // Asigna el valor de Country al parámetro @Country del comando SQL
            comando.Parameters.AddWithValue("Country", personal.Country);

            // Asigna el valor de Phone al parámetro @Phone del comando SQL
            comando.Parameters.AddWithValue("Phone", personal.Phone);

            // Ejecuta el comando SQL (INSERT o UPDATE) y retorna el número de registros afectados
            var insertados = comando.ExecuteNonQuery();

            // Retorna el número de registros afectados por el comando SQL
            return insertados;
        }

        // Método que actualiza un registro existente en la tabla Suppliers
        public int ActualizarPersonal(Person person, int id)
        {
            // Establece una conexión a la base de datos usando un método de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Define la cadena SQL para actualizar un registro en la tabla Suppliers
                String ActualizarPersona = "";
                ActualizarPersona = ActualizarPersona + "UPDATE [dbo].[Suppliers] " + "\n";   // Actualiza la tabla Suppliers
                ActualizarPersona = ActualizarPersona + "   SET [CompanyName] = @CompanyName" + "\n"; // Asigna nuevo valor a CompanyName
                ActualizarPersona = ActualizarPersona + "      ,[ContactName] = @ContactName" + "\n"; // Asigna nuevo valor a ContactName
                ActualizarPersona = ActualizarPersona + "      ,[ContactTitle] = @ContactTitle" + "\n"; // Asigna nuevo valor a ContactTitle
                ActualizarPersona = ActualizarPersona + "      ,[City] = @City" + "\n";                // Asigna nuevo valor a City
                ActualizarPersona = ActualizarPersona + "      ,[PostalCode] = @PostalCode" + "\n";  // Asigna nuevo valor a PostalCode
                ActualizarPersona = ActualizarPersona + "      ,[Country] = @Country" + "\n";         // Asigna nuevo valor a Country
                ActualizarPersona = ActualizarPersona + "      ,[Phone] = @Phone" + "\n";            // Asigna nuevo valor a Phone
                ActualizarPersona = ActualizarPersona + $" WHERE SupplierID = '{id}'";              // Especifica el registro a actualizar mediante SupplierID

                // Crea un objeto SqlCommand para ejecutar el comando SQL de actualización
                using (var comando = new SqlCommand(ActualizarPersona, conexion))
                {
                    // Establece los parámetros del comando con los valores de la persona
                    int actualizados = parametrosPersonal(person, comando);

                    // Retorna el número de registros actualizados
                    return actualizados;
                }
            }
        }

        // Método que elimina un registro de la tabla Suppliers basado en el SupplierID
        public int EleminarPersonal(int id)
        {
            // Establece una conexión a la base de datos usando un método de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Define la cadena SQL para eliminar un registro de la tabla Suppliers
                String deletePerson = "";
                deletePerson = deletePerson + "DELETE FROM [dbo].[Suppliers] " + "\n";   // Elimina registros de la tabla Suppliers
                deletePerson = deletePerson + $"      WHERE SupplierID='{id}'";         // Condición para eliminar el registro con el SupplierID especificado

                // Crea un objeto SqlCommand para ejecutar el comando SQL de eliminación
                using (SqlCommand comando = new SqlCommand(deletePerson, conexion))
                {
                    // Establece el parámetro @SupplierID en el comando SQL
                    comando.Parameters.AddWithValue("@SupplierID", id);

                    // Ejecuta el comando SQL y retorna el número de registros eliminados
                    int eliminados = comando.ExecuteNonQuery();

                    // Retorna el número de registros eliminados
                    return eliminados;
                }
            }
        }
        // Método que obtiene un registro de la tabla Suppliers basado en el SupplierID
        public Person ObtenerPorId(int id)
        {
            // Establece una conexión a la base de datos usando un método de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Define la cadena SQL para seleccionar un registro de la tabla Suppliers
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [SupplierID] " + "\n";   // Selecciona la columna SupplierID
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";   // Selecciona la columna CompanyName
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";   // Selecciona la columna ContactName
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";  // Selecciona la columna ContactTitle
                selectFrom = selectFrom + "      ,[Address] " + "\n";       // Selecciona la columna Address
                selectFrom = selectFrom + "      ,[City] " + "\n";          // Selecciona la columna City
                selectFrom = selectFrom + "      ,[Region] " + "\n";        // Selecciona la columna Region
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";    // Selecciona la columna PostalCode
                selectFrom = selectFrom + "      ,[Country] " + "\n";       // Selecciona la columna Country
                selectFrom = selectFrom + "      ,[Phone] " + "\n";         // Selecciona la columna Phone
                selectFrom = selectFrom + "      ,[Fax] " + "\n";           // Selecciona la columna Fax
                selectFrom = selectFrom + "      ,[HomePage] " + "\n";      // Selecciona la columna HomePage
                selectFrom = selectFrom + "  FROM [dbo].[Suppliers]" + "\n"; // Indica la tabla de la cual seleccionar
                selectFrom = selectFrom + $" WHERE SupplierID='{id}'";      // Filtro para seleccionar el registro con el SupplierID específico

                // Crea un objeto SqlCommand para ejecutar el comando SQL de selección
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    // Establece el parámetro SupplierID en el comando SQL
                    comando.Parameters.AddWithValue("SupplierID", id);

                    // Ejecuta el comando SQL y obtiene un SqlDataReader para leer los resultados
                    var reader = comando.ExecuteReader();

                    // Variable para almacenar el objeto Person obtenido
                    Person personas = null;

                    // Lee el primer registro del SqlDataReader
                    if (reader.Read())
                    {
                        // Si se lee un registro, convierte los datos en un objeto Person usando el método LeerDelDataReader
                        personas = LeerDelDataReader(reader);
                    }

                    // Retorna el objeto Person obtenido, o null si no se encontró ningún registro
                    return personas;
                }
            }
        }
    }
}
