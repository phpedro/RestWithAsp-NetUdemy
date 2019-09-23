using RestWithAspNetUdemy.Models;
using System.Collections.Generic;
namespace RestWithAspNetUdemy.Services
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        bool Delete(long id);
    }
}