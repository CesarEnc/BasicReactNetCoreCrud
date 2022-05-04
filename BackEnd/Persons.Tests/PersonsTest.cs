using NUnit.Framework;
using Persons.Api.Exceptions;
using PersonsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persons.Tests
{
    public class PersonTests
    {
        [Test]
        public void GetPersons_IsNotEmpty()
        {
            var personService = Utils.Helper.GetPersonService();

            Assert.IsNotEmpty(personService.GetAll());
        }

        [Test]
        public void PostPersons_IsSaving()
        {
            var person = new Person { Name = "Juan", SurName = "ele", Mail = "Test@gmail.com" };
            var personService = Utils.Helper.GetPersonService();

            personService.Add(person);

            Assert.IsTrue(personService.GetAll().Contains(person));
        }
        [Test]
        public void DeletePersons_IsDeletingAll()
        {
            var personService = Utils.Helper.GetPersonService();

            foreach (var person in personService.GetAll())
            {
                personService.Delete(person.Id);
            }

            Assert.IsEmpty(personService.GetAll());
        }
        [Test]
        public void DeletePersonsNotInList_IsThrowingException()
        {
            var personService = Utils.Helper.GetPersonService();

            int badId = personService.GetAll().Max(x => x.Id) + 1;

            Assert.ThrowsAsync<KeyNotFoundException>(() => personService.Delete(badId));
        }

        [Test]
        public void DuplicateEmailInPersons_IsThrowingException()
        {
            var person = new Person { Name = "Juan", SurName = "Doe", Mail = "TestDoe@gmail.com" };
            var personWithMailInUse = new Person { Name = "Pedro", SurName = "Doe", Mail = "TestDoe@gmail.com" };
            var personService = Utils.Helper.GetPersonService();

            personService.Add(person);

            Assert.ThrowsAsync<MailInUseException>(() => personService.Add(personWithMailInUse));
        }

    }
}