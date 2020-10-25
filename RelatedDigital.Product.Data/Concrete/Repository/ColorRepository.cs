using System;
using System.Collections.Generic;
using System.Text;
using RelatedDigital.Product.Data.Concrete.Contexts;
using RelatedDigital.Product.Data.Concrete.Entities;
using RelatedDigital.Product.Data.Interfaces;

namespace RelatedDigital.Product.Data.Concrete.Repository
{
    public class ColorRepository : IRepository<Colors>
    {
        public void Add(Colors entity)
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            relatedDigitalContext.Colors.Add(entity);
            relatedDigitalContext.SaveChanges();

        }

        public Colors GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Colors entity)
        {
            throw new NotImplementedException();
        }
    }
}
