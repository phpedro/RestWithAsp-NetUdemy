using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithAspNetUdemy.Models;
using RestWithAspNetUdemy.Models.Context;

namespace RestWithAspNetUdemy.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;
        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }
        public bool Delete(long id)
        {
            return true;
        }
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person p = MockPerson(i);
                persons.Add(p);
            }
            return persons;
        }
        private Person MockPerson(int i)
        {
            Person p = new Person() {
                Id = i,
                Address = i + RandomStr(),
                FirstName = i + RandomStr(),
                LastName = i + RandomStr(),
                Gender = (DateTime.Now.Second / 2) == 0.00M ? "M" : "F"
            };
            return p;
        }
        private string RandomStr()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        public Person FindById(long id)
        {
            return new Person(){
                Id=id,
                FirstName = "Pedro",                
                LastName = "Henrique",
                Address = "Rua Ademar Vieira Tavares, 252",
                Gender = "Male",
            };
        }
        public Person Update(Person person)
        {
            return person;
        }
    }
}
