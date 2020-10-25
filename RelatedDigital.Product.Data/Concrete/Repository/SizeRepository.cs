using System;
using System.Collections.Generic;
using System.Text;
using RelatedDigital.Product.Data.Concrete.Contexts;
using RelatedDigital.Product.Data.Concrete.Entities;
using RelatedDigital.Product.Data.Interfaces;

namespace RelatedDigital.Product.Data.Concrete.Repository
{
    public class SizeRepository : IRepository<Size>
    {
        public void Add(Size entity)
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            relatedDigitalContext.Sizes.Add(entity);
            relatedDigitalContext.SaveChanges();

        }

        public Size GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Size entity)
        {
            throw new NotImplementedException();
        }
    }
}
