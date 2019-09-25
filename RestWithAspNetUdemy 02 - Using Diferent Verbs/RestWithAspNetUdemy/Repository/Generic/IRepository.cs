using RestWithAspNetUdemy.Models.Base;
using System.Collections.Generic;

namespace RestWithAspNetUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T Object);
        T FindById(long id);
        List<T> FindAll();
        T Update(T Object);
        bool Delete(long id);
        bool Exists(long? id);
    }
}
