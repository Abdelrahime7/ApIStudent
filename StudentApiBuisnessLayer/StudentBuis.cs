using StudentApiDataAccessLayer;


namespace StudentApiBuisnessLayer
{
    public class StudentBuis
    {


       public  static List<StudentDTO> AllStudents()
        {
            return StudentsData.GetAllStudents();
        }

        public static List<StudentDTO> PassedStudents()
        {
            return StudentsData.GetPassedStudents();
        }

        public static double AverageGrad()
        {
            return StudentsData.AverageGrad();
        }
    }
}
