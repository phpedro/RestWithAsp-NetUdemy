using RestWithAspNetUdemy.Data.Converter;
using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public PersonVO Parse(Person origin)
        {
            if (origin == null) return new PersonVO();
            else return new PersonVO()
            {
                 id = origin.id,
                 Address = origin.Address,
                 FirstName = origin.FirstName,
                 LastName = origin.LastName,
                 Gender = origin.Gender
            };
        }
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return new Person();
            else
                return new Person()
                {
                    Address = origin.Address,
                    FirstName = origin.FirstName,
                    Gender = origin.Gender,
                    id = origin.id,
                    LastName = origin.LastName
                };
        }

        public List<PersonVO> ParseList(List<Person> origin)
        {
            if (origin == null) return new List<PersonVO>();
            else
                return origin.Select(x => Parse(x)).ToList();
        }

        public List<Person> ParseList(List<PersonVO> origin)
        {
            if (origin == null) return new List<Person>();
            else
                return origin.Select(x => Parse(x)).ToList();
        }
    }
}
