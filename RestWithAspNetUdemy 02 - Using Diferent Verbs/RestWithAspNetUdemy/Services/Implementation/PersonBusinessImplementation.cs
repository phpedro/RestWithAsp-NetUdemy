using RestWithAspNetUdemy.Models;
using RestWithAspNetUdemy.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Services.Implementation
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private MySQLContext _context;
        public PersonBusinessImplementation(MySQLContext context)
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
            if (!Exist(id))
            {
                return false;
            }
            else
            {
                var result = _context.Persons.SingleOrDefault(p => p.Id == id);
                try
                {
                    if (result != null)
                    {
                        _context.Persons.Remove(result);
                        _context.SaveChanges();
                        return true;
                    }
                    return false;
                    
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public List<Person> FindAll()
        {
            List<Person> persons = _context.Persons.ToList();
            return persons;
        }
        private Person MockPerson(int i)
        {
            Person p = new Person()
            {
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
            var retorno = _context.Persons.SingleOrDefault(x => x.Id == id);
            return retorno;
        }
        public Person Update(Person person)
        {
            if (!Exist(person.Id))
            {
                return new Person();
            }
            else
            {
                var result = _context.Persons.SingleOrDefault(p => p.Id == person.Id);
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                    return person;
                } catch(Exception ex)
                {
                    throw ex;
                }
            }

        }
        public bool Exist(long? id)
        {
            return _context.Persons.Any(x => x.Id == id);
        }
    }
}
