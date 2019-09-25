using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestWithAspNetUdemy.Business;
using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Models;
using Tapioca.HATEOAS;
namespace RestWithAspNetUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personBusiness;
        public PersonsController(IPersonBusiness person)
        {
            _personBusiness = person;
        }
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            var persons = _personBusiness.FindAll();           
            return Ok(persons);
        }
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person != null)
                return Ok(person);
            else
                return NotFound();
        }
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]PersonVO person)
        {
            if (person != null)
                return new ObjectResult(_personBusiness.Create(person));
            else
                return NotFound();
        }
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]PersonVO person)
        {
            if (person != null)
                return new ObjectResult(_personBusiness.Update(person));
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            if (_personBusiness.Delete(id))
                return NoContent();
            else
                return BadRequest();
        }
    }
}