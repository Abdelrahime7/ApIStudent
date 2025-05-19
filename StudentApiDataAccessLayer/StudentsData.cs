
using Microsoft.Data.SqlClient;
using System.Data;

namespace StudentApiDataAccessLayer
{
 
    public static class StudentsData
    {

       

       public static List<StudentDTO>GetAllStudents()
        {
            var studentsList = new List<StudentDTO>();

            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))

            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllStudents",con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentsList.Add(new StudentDTO(
                                reader.GetInt32(reader.GetOrdinal("ID")),
                                reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetInt32(reader.GetOrdinal("Age")),
                                reader.GetInt32(reader.GetOrdinal("Grad"))
                                ));

                        }
                    }
                }
             }
                return studentsList;
           
        }


        public static List<StudentDTO> GetPassedStudents()
        {
            var studentsList = new List<StudentDTO>();

            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))

            {
                using (SqlCommand cmd = new SqlCommand("SP_GetPassedStudents", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentsList.Add(new StudentDTO(
                                reader.GetInt32(reader.GetOrdinal("ID")),
                                reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetInt32(reader.GetOrdinal("Age")),
                                reader.GetInt32(reader.GetOrdinal("Grad"))
                                ));

                        }
                    }
                }
            }
            return studentsList;

        }

    }
}
