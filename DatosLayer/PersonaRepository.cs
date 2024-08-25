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
        public List<Person> ObtenerDatos()
        {
            using (var conexion=DataBase.GetSqlConnection())
            {
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [BusinessEntityID] " + "\n";
                selectFrom = selectFrom + "      ,[PersonType] " + "\n";
                selectFrom = selectFrom + "      ,[NameStyle] " + "\n";
                selectFrom = selectFrom + "      ,[Title] " + "\n";
                selectFrom = selectFrom + "      ,[FirstName] " + "\n";
                selectFrom = selectFrom + "      ,[MiddleName] " + "\n";
                selectFrom = selectFrom + "      ,[LastName] " + "\n";
                selectFrom = selectFrom + "      ,[Suffix] " + "\n";
                selectFrom = selectFrom + "      ,[EmailPromotion] " + "\n";
                selectFrom = selectFrom + "      ,[AdditionalContactInfo] " + "\n";
                selectFrom = selectFrom + "      ,[Demographics] " + "\n";
                selectFrom = selectFrom + "      ,[rowguid] " + "\n";
                selectFrom = selectFrom + "      ,[ModifiedDate] " + "\n";
                selectFrom = selectFrom + "  FROM [Person].[Person]";

                using (SqlCommand comando=new SqlCommand(selectFrom,conexion))
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    List<Person> persona = new List<Person>();

                    while (reader.Read())
                    {
                        var person = LeerDelDataReader(reader);
                        persona.Add(person);
                    }
                    return persona;
                }
            }
        }

        public Person LeerDelDataReader(SqlDataReader reader)
        {
            Person persona = new Person();
            persona.BusinessEntityID = reader["BusinessEntityID"] == DBNull.Value ? 0 : (int)reader["BusinessEntityID"];
            persona.PersonType = reader["PersonType"] == DBNull.Value ? "" : (string)reader["PersonType"];
            persona.NameStyle = reader["NameStyle"] == DBNull.Value ? false : (bool)reader["NameStyle"];
            persona.FirstName = reader["FirstName"] == DBNull.Value ? "" : (string)reader["FirstName"];
            persona.LastName = reader["LastName"] == DBNull.Value ? "" : (string)reader["LastName"];
            persona.EmailPromotion = reader["EmailPromotion"] == DBNull.Value ? 0 : (int)reader["EmailPromotion"];
            persona.rowguid = reader["rowguid"] == DBNull.Value ? Guid.Empty : (Guid)reader["rowguid"];
            persona.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ModifiedDate"];
            return persona;
        }
    }
}
