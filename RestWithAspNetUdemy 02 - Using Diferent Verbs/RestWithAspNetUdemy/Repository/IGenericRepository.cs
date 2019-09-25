using System;
using System.Collections.Generic;

namespace RestWithAspNetUdemy.Repository
{
    public interface IGenericRepository
    {
        Object Create(Object Object);
        Object FindById(long id);
        List<Object> FindAll();
        Object Update(Object Object);
        bool Delete(long id);
        bool Exists(long? id);
    }
}
