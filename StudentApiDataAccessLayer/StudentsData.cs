
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.Pkcs;

namespace StudentApiDataAccessLayer
{

    public static class StudentsData
    {



        public static List<StudentDTO> GetAllStudents()
        {
            var studentsList = new List<StudentDTO>();

            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))

            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllStudents", con))
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


        public static double AverageGrad()
        {
            var AverageGrade = 0d;

            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))

            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAerageGrad", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        AverageGrade = Convert.ToDouble(result);
                    }
                    else
                        AverageGrade = 0;
                }
            }
            return AverageGrade;

        }


        public static StudentDTO Find(int ID)
        {


            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))

            {
                using (SqlCommand cmd = new SqlCommand("SP_FindStudent", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);

                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StudentDTO(
                                reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetInt32(reader.GetOrdinal("Age")),
                                reader.GetInt32(reader.GetOrdinal("Grad"))

                                );

                        }
                        else return null;
                    }



                }
            }

        }


        public static int AddStudent(StudentDTO SDTO)
        {


            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))

            {
                using (SqlCommand cmd = new SqlCommand("SP_AddStudent", con))

                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name",SDTO.Name);
                    cmd.Parameters.AddWithValue("@Age", SDTO.Age);
                    cmd.Parameters.AddWithValue("@Grad", SDTO.Grade);
                    var OutIdParameter = new SqlParameter("@ID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output,
                    };
                    cmd.Parameters.Add(OutIdParameter);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    return (int) OutIdParameter.Value;


                }

            }
        }

        public static bool UpdateStudent(StudentDTO SDTO )
        {


            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))

            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateStudent", con))

                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", SDTO.Id);
                    cmd.Parameters.AddWithValue("@Name", SDTO.Name);
                    cmd.Parameters.AddWithValue("@Age", SDTO.Age);
                    cmd.Parameters.AddWithValue("@Grad", SDTO.Grade);
                    
                  

                    con.Open();

                    cmd.ExecuteNonQuery();
                    return true;

                }

            }
        }
    }
}