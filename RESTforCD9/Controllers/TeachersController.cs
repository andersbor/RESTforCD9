
using Microsoft.AspNetCore.Mvc;
using RESTforCD9.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTforCD9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly TeachersRepository teachersRepository;
        public TeachersController(TeachersRepository repo)
        {
            teachersRepository = repo;
        }

        // GET: api/<TeachersController>
        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return teachersRepository.GetTeachers();
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public Teacher? Get(int id)
        {
            return teachersRepository.GetTeacher(id);
        }

        // POST api/<TeachersController>
        [HttpPost]
        public ActionResult<Teacher> Post([FromBody] Teacher value)
        {
            try
            {
                Teacher tea = teachersRepository.AddTeacher(value);
                return Created(
                Url.ActionContext.HttpContext.Request.Path + "/" + tea.Id,
                               tea);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
