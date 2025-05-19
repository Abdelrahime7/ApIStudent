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


        [HttpGet("{ID}", Name = "FindStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<StudentDTO>> FindStudent(int ID)
        {
            var student = StudentBuis.find(ID);
            if (student is null)
            {
                return NotFound("No Student Found");

            }
            return Ok(student);

        }



    }
}
