using Microsoft.AspNetCore.Mvc;
using Template_Web_API.Dto.Student;
using Template_Web_API.Services;

namespace Template_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("")]
        public ActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            StudentDTO student = _studentService.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("")]
        public ActionResult Create(CreateStudentDTO dto)
        {
            StudentDTO createdStudent = _studentService.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = createdStudent.Id }, createdStudent);

        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateStudentDTO dto)
        {
            StudentDTO updatedStudent = _studentService.Update(dto);
            if (id != dto.Id)
            {
                return BadRequest();
            }

            _studentService.Update(dto);
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isDeleted = _studentService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
