using PersonsApi.Models;

namespace PersonsApi.Interfaces.Services
{
    public interface IPersonsService
    {
        public IQueryable<Person> GetAll();
        public Task Add(Person newT);
        public Task Delete(int id);
    }
}
