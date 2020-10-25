using System;
using System.Collections.Generic;
using System.Text;

namespace RelatedDigital.Product.Business.Interfaces
{
  public  interface IProductsService<T> where T:class
    {        
        IEnumerable<T> GetAll();
       
    }
}
