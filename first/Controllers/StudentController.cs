using first.Data;
using first.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace first.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  StudentController : Controller
    {
        //ILogger Interface Implementation 
        private readonly ILogger<StudentController> _logger;

        private readonly CollegeDBContext _dbcontext;

        // Dependency Injection 
            public StudentController(ILogger<StudentController> logger, CollegeDBContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("All")]

        
        // with async and await 
        public async Task<ActionResult<IEnumerable<StudentdDTO>>> GetStudents()
        {
            _logger.LogInformation("This message from Ilogger");
             var student =await _dbcontext.Student.Select(s =>new StudentdDTO()
            {
                    Id = s.Id,
                    StudentName = s.StudentName,
                    Email =s.Email,
                    Address =s.Address

            }).ToListAsync();
            return Ok(student);  

            //Get all data from Entity Framework 
            //var student = _dbcontext.Student;

            //----------   used when we have to read particular column  ---------------

            // var student = new List<StudentdDTO>(); // Creates an empty list
            //foreach (var item in student)
            //{
            //    StudentdDTO obj = new StudentdDTO()
            //    {
            //        Id = item.Id,
            //        StudentName = item.StudentName,
            //        Email = item.Email,
            //        Address = item.Address

            //   63.- };

            //}
            //return Ok(_dbcontext.Student);





        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentbyId")]
        public async Task<ActionResult<Student>> GetStudentbyId(int id)
        {
            if (id <= 0)
            {
                //400 - BadRequest 
                _logger.LogError("Bad Request");  // used to show Error type msg in console window 
                return BadRequest("Please Enter the Valid ID");
            }


            var Student = await _dbcontext.Student.Where(n => n.Id == id).FirstOrDefaultAsync();

            //404 - Not Found 
            if (Student == null)
                return NotFound($"The student with id {id} Not Found ");

            //200 - Ok for successful Result
            return Ok(Student);
        }

        [HttpGet ("{name:alpha}", Name ="GetStudentbyName")]
        public Student GetStudentbyname(string name)
        {
            return _dbcontext.Student.Where(n => n.StudentName == name).FirstOrDefault();
        }

        //------------  POST Request ---------------    --------------- 

        [HttpPost]
        [Route("AddNewStudent")]
        public ActionResult<StudentdDTO> CreateStudent([FromBody] StudentdDTO model)
        {
            if (model == null)
                return BadRequest();

            Student studentObj = new Student()
            {
                StudentName = model.StudentName,
                Email = model.Email,
                Address = model.Address,
                Dob = model.Dob


            };
            _dbcontext.Student.AddAsync(studentObj);
            _dbcontext.SaveChangesAsync();
            model.Id = studentObj.Id;


            return Ok(model);
        }

        // ------------------  DELETE Request ----------

        //[HttpDelete("{id}")]
        //public bool DeleteStudentbyid(int id)
        //{
        //    var student = _dbcontext.Students.Where(n => n.Id == id).FirstOrDefault();
        //    _dbcontext.Students.Remove(student);

        //    return true;
        //}

        //Or Delete 

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            if (id <= 0)
                return BadRequest();

            var student = await _dbcontext.Student.Where(s => s.Id == id).FirstOrDefaultAsync();

            if (student == null)
                return NotFound($"The student with id {id} Not Found ");
            _dbcontext.Student.Remove(student);
            _dbcontext.SaveChanges();

            return Ok(true);
        }

        // ------------------ PUT/ Update Request -------------

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentdDTO> UpdateStudent([FromBody] StudentdDTO model)
        {
            if (model == null && model.Id <= 0)
                return BadRequest();

            var existingStudent = _dbcontext.Student.Where(s => s.Id == model.Id).FirstOrDefault();

            if (existingStudent == null)
                return NotFound();

            existingStudent.StudentName = model.StudentName;
            existingStudent.Email = model.Email;
            existingStudent.Address = model.Address;
            existingStudent.Dob = model.Dob;

            _dbcontext.SaveChanges();

            return NoContent();
        }

    }
}
