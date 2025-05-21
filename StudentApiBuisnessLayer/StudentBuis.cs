using StudentApiDataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;


namespace StudentApiBuisnessLayer
{
    public class StudentBuis
    {
        public StudentDTO DTO { get {return new(this.Id, this.Name, this.Age, this.Grad); } }

        public enum Mode
        { ADD=1,Update=2
            
        }
        public Mode mode;

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public int Grad { get; set; }

        public StudentBuis(StudentDTO student,Mode mode = Mode.ADD)
        {
            this.Id = student.Id;
            this.Name =student. Name;
            this.Age = student.Age;
            this.Grad = student. Grade;

            this.mode = mode;
        }
         
       public bool AddStudent()
        {
         
            var NewStudentID  =StudentsData.AddStudent(DTO);
            return NewStudentID > 0;
        }
        public bool UpdateStudent()
        {
            return StudentsData.UpdateStudent(DTO);
           
        }


        public bool Save()
        {
            switch (mode)
            {

                case Mode.ADD:


                   if (AddStudent())
                   {
                       mode = Mode.Update;
                       return true;
                   }
                    else
                    {
                        return false;
                    }
                case Mode.Update:

                    if (UpdateStudent())
                    {
                        mode = Mode.ADD;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
            }
            return false;
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


        public static StudentBuis? find(int ID)
        {

            var studentDto = StudentsData.Find(ID);
            if (studentDto !=null)
            {
                return new StudentBuis(studentDto, Mode.Update); 
            }


            else
                return null;
        }

        public static bool DeletStudent(int ID)
        {
            return StudentsData.DeleteStudent(ID);
        }

    }
}
