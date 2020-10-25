using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RelatedDigital.Product.Data.Concrete.Entities;

namespace RelatedDigital.Product.Data.Interfaces
{
   public interface IRepository<T> where T:class
    {
        T GetById(int id);
        void Add(T entity);
        bool Update(T entity);   
        void Remove(int id);
    
    }
}
