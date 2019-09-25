using RestWithAspNetUdemy.Data.Converters;
using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Models;
using RestWithAspNetUdemy.Repository;
using RestWithAspNetUdemy.Repository.Generic;
using RestWithAspNetUdemy.Repository.Implementation;
using System.Collections.Generic;

namespace RestWithAspNetUdemy.Business.Implementation
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;
        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }
        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }
        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }
        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
        public bool Exists(long? id)
        {
            return _repository.Exists(id);
        }
    }
}
