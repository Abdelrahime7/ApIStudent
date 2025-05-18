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





    }
}
