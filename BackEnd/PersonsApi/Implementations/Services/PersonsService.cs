using Persons.Api.Exceptions;
using PersonsApi.Interfaces.Services;
using PersonsApi.Models;

namespace PersonsApi.Implementations.Services
{
    public class PersonsService : IPersonsService
    {
        private readonly PersonsDBContext _context;

        public PersonsService(PersonsDBContext context) => _context = context;

        public async Task Add(Person newPerson)
        {
            var mailExist = _context.Persons.Any(x => x.Mail == newPerson.Mail);
            if (mailExist) throw new MailInUseException($"{newPerson.Mail} Already in Use.");

            await _context.Persons.AddAsync(newPerson);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) throw new KeyNotFoundException("User not Found");

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Person> GetAll() => _context.Persons;
    }
}
