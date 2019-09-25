using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Business;
using RestWithAspNetUdemy.Models;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private IBookBusiness _bookBusiness;
        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post([FromBody]BookVO book)
        {            
            _bookBusiness.Create(book);
            return Ok(book);
        }
        [HttpPut]
        public IActionResult Put([FromBody]BookVO book)
        {
            return Created("Criado", book);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_bookBusiness.Delete(id)) return NoContent();
            else return BadRequest();
        }
    }
}
