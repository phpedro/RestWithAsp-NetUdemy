using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Models;
using RestWithAspNetUdemy.Services;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personService;
        public PersonsController(IPersonBusiness person)
        {
            _personService = person;
        }        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person != null)
                return Ok(person);
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {

            if (person != null)
                return new ObjectResult(_personService.Create(person));
            else
                return NotFound();
        }
        [HttpPut]
        public IActionResult Put([FromBody]Person person)
        {
            if (person != null)
                return new ObjectResult(_personService.Update(person));
            else
                return NotFound();
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_personService.Delete(id))
                return NoContent();
            else
                return BadRequest();
        }
    }
}
