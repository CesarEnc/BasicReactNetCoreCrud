using Microsoft.AspNetCore.Mvc;
using Persons.Api.Exceptions;
using PersonsApi.Interfaces.Services;
using PersonsApi.Models;

namespace PersonsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService _service;
        public PersonsController(IPersonsService service) => _service = service;

        [HttpGet]
        public IEnumerable<Person> Get() => _service.GetAll();

        [HttpPost]
        public async Task Post(Person newPerson)
        {
            try
            {
                await _service.Add(newPerson);
            }
            catch (MailInUseException e)
            {
                BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await _service.Delete(id);
            }
            catch (KeyNotFoundException e)
            {
                NotFound(e.Message);
            }

        }

    }
}
