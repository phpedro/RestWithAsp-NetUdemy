using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Models;
using System.Collections.Generic;
namespace RestWithAspNetUdemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        bool Delete(long id);
    }
}