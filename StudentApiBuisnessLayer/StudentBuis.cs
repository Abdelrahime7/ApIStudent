using StudentApiDataAccessLayer;


namespace StudentApiBuisnessLayer
{
    public class StudentBuis
    {


       public  static List<StudentDTO> AllStudents()
        {
            return StudentsData.GerAllStudents();
        }
    }
}
