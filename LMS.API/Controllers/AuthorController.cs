using LMS.API.Repositories;
using LMS.Shared.DataModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo authorRepo;

        public AuthorController(IAuthorRepo authorRepo)
        {
            this.authorRepo = authorRepo;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Authors> Get()
        {
            return authorRepo.GetAuthors();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public ActionResult<Authors> Get(int id)
        {
            return authorRepo.GetAuthor(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Authors model)
        {
            try
            {
                var result = await authorRepo.AddOrEditAuthor(model);

                return (result) ? Ok(model) : StatusCode(StatusCodes.Status304NotModified, null);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<AuthorController>/5
        //[HttpPut("{id}")]
        //public ActionResult Put(int id, [FromBody] Authors model)
        //{
        //}

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await authorRepo.DeleteAuthor(id);

                return (result) ? Ok("Deleted Successfully") : StatusCode(StatusCodes.Status304NotModified, "Unable to delete author of id: " + id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
