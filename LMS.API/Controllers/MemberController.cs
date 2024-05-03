using LMS.API.Repositories;
using LMS.Shared.DataModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepo MemberRepo;

        public MemberController(IMemberRepo MemberRepo)
        {
            this.MemberRepo = MemberRepo;
        }

        // GET: api/<MemberController>
        [HttpGet]
        public IEnumerable<Members> Get()
        {
            return MemberRepo.GetMembers();
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public ActionResult<Members> Get(int id)
        {
            return MemberRepo.GetMember(id);
        }

        // POST api/<MemberController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Members model)
        {
            try
            {
                var result = await MemberRepo.AddOrEditMember(model);

                return (result) ? Ok(model) : StatusCode(StatusCodes.Status304NotModified, null);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<MemberController>/5
        //[HttpPut("{id}")]
        //public ActionResult Put(int id, [FromBody] Members model)
        //{
        //}

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await MemberRepo.DeleteMember(id);

                return (result) ? Ok("Deleted Successfully") : StatusCode(StatusCodes.Status304NotModified, "Unable to delete Member of id: " + id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
