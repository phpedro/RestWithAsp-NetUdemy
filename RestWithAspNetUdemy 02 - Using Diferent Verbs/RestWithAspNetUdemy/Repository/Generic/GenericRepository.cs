using Microsoft.EntityFrameworkCore;
using RestWithAspNetUdemy.Models.Base;
using RestWithAspNetUdemy.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        private DbSet<T> dataSet;
        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataSet = context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                if (Exists(id))
                {
                    var item = dataSet.SingleOrDefault(x => x.id == id);
                    dataSet.Remove(item);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Exists(long? id)
        {
            return dataSet.Any(x => x.id == id);
        }
        public List<T> FindAll()
        {
            return dataSet.ToList();
        }
        public T FindById(long id)
        {
            return dataSet.SingleOrDefault(x => x.id == id);
        }
        public T Update(T item)
        {
            try
            {
                if (Exists(item.id))
                {
                    var antigo = dataSet.SingleOrDefault(x => x.id == item.id);
                    _context.Entry(antigo).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
