using Microsoft.AspNetCore.Mvc;
using StudentApiBuisnessLayer;
using StudentApiDataAccessLayer;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("Api/Students")]
    public class StudentController : ControllerBase
    {

        [HttpGet("All", Name = "GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<StudentDTO>> AllStudents()
        {
            var StudentsLIst = StudentBuis.AllStudents();
            if (StudentsLIst.Count==0)
            {
                return NotFound("No Student Found");

            }
            return Ok(StudentsLIst);

        }


        [HttpGet("Passed", Name = "GetPassedStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<StudentDTO>> PassedStudents()
        {
            var PassedStudentsLIst = StudentBuis.PassedStudents();
            if (PassedStudentsLIst.Count == 0)
            {
                return NotFound("No Student Found");

            }
            return Ok(PassedStudentsLIst);

        }

        [HttpGet("Average", Name = "AverageGrad")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult <double> AverageGrad()
        {
            var averageGrad = 0d;

            averageGrad = StudentBuis.AverageGrad();
           
            return Ok(averageGrad);

        }


        [HttpGet("{ID}", Name = "GetStudentByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<StudentDTO> FindStudent(int ID)
        {
            if (ID> 1)
            {
                return BadRequest($"invalid {ID}");
            }

            // we retriev the whole studentBuiss here ,maybe we  need some of its method to do some logic
            var student = StudentBuis.find(ID);

            if (student is null)
            {
                return NotFound("No Student Found");
            }
            else
            {
                //here we just  the needed data to  client 
                StudentDTO SDTO = student.DTO;
                return Ok(SDTO);
            }
        }


        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentDTO>  AddStudent (StudentDTO SDTO)
        {
            if (SDTO == null ||   string.IsNullOrEmpty(SDTO.Name)||SDTO.Grade < 0 || SDTO.Grade>100)
            {
                return BadRequest($"invalid Student Data ");
            }


            StudentBuis student = new StudentBuis(SDTO);
            student.Save();

            SDTO.Id = student.Id;

            return CreatedAtRoute($"GetStudentByID", new { Id = SDTO.Id }, SDTO);
               

          
           
        }



    }
}
