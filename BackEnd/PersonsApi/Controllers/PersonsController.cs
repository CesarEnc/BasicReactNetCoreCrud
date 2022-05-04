using Microsoft.AspNetCore.Mvc;
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
        public async Task Post(Person newPerson) => await _service.Add(newPerson);

        [HttpDelete("{id}")]
        public async Task Delete(int id) => await _service.Delete(id);

    }
}
