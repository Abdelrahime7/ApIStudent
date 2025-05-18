using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApiDataAccessLayer
{



    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public  int Age { get; set; }
        public int Grade { get; set; }

        public StudentDTO(int ID,string Name,int Age,int Grade)
        {
            this.Id = ID;
            this.Name = Name;
            this.Age = Age;
            this.Grade = Grade;
        }

    }

}
