using System;
using System.Collections.Generic;
using System.Text;

namespace RelatedDigital.Product.Business.Interfaces
{
  public interface ITotalService<T> where T : class
    {      
       List<T> GetAll();
      
    }
}
