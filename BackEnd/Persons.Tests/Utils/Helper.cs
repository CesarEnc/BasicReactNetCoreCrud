using Microsoft.EntityFrameworkCore;
using PersonsApi.Implementations.Services;
using PersonsApi.Interfaces.Services;
using PersonsApi.Models;
using System;
using System.Threading.Tasks;

namespace Persons.Tests.Utils
{
    public static class Helper
    {
        private static async Task<PersonsDBContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<PersonsDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new PersonsDBContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Persons.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Persons.Add(new Person()
                    {
                        Mail = $"testuser{i}@example.com",
                        Name = $"test{i}",
                        SurName = $"test{i}"
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        public static IPersonsService GetPersonService(PersonsDBContext? context = null)
        {
            if (context == null) context = GetDatabaseContext().Result;
            return new PersonsService(context);
        }
    }
}
