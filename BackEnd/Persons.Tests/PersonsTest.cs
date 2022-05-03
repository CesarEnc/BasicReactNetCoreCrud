using NUnit.Framework;
using PersonsApi.Models;
using System.Linq; 

namespace Persons.Tests
{
    public class PersonTests
    {
        [Test]
        public void GetPersons_IsNotEmpty()
        {
            var service = Utils.Helper.GetPersonService();
            Assert.IsNotEmpty(service.GetAll());
        }

        [Test]
        public void PostPersons_IsSaving()
        {
            var person = new Person { Name = "Juan", SurName = "ele", Mail = "Test@gmail.com"};
            var service = Utils.Helper.GetPersonService();
            service.Add(person);

            Assert.IsTrue(service.GetAll().Contains(person));
        }
        [Test]
        public void DeletePersons_IsDeletingAll()
        {
            var service = Utils.Helper.GetPersonService();
            foreach (var person in service.GetAll())
            {
                service.Delete(person.Id);
            }
            Assert.IsEmpty(service.GetAll());
        }

    }
}