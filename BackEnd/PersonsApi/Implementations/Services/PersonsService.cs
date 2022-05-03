using Microsoft.EntityFrameworkCore;
using PersonsApi.Models;
using PersonsApi.Interfaces.Services;

namespace PersonsApi.Implementations.Services
{
    public class PersonsService : IPersonsService
    {
        private readonly PersonsDBContext _context;

        public PersonsService(PersonsDBContext context)
        {
            _context = context;
        }
        public async Task Add(Person newT)
        {
            await _context.Persons.AddAsync(newT);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Persons.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException();
            _context.Persons.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Person> GetAll()
        {
            return _context.Persons;
        }

    }
}
