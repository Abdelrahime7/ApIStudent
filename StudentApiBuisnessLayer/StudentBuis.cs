using StudentApiDataAccessLayer;
using System.Runtime.CompilerServices;


namespace StudentApiBuisnessLayer
{
    public class StudentBuis
    {


        public enum Mode
        { ADD=1,Update=2
            
        }
        public Mode mode;

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public int Grade { get; set; }

        public StudentBuis(StudentDTO student,Mode mode)
        {
            this.Id = student.Id;
            this.Name =student. Name;
            this.Age = student.Age;
            this.Grade = student. Grade;

            this.mode = mode;
        }




        public static List<StudentDTO> AllStudents()
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


        public static StudentDTO find(int ID)
        {
            if (StudentsData.Find(ID) != null)

            {
                var studentDto = StudentsData.Find(ID);
                StudentBuis buis = new StudentBuis(studentDto, Mode.Update);
                return studentDto;
            }
            else return null;
        }


    }
}
