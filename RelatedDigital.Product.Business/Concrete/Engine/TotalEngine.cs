using System;
using System.Collections.Generic;
using System.Text;
using RelatedDigital.Product.Business.Interfaces;
using RelatedDigital.Product.Common.Concrete.DTO.VM;
using RelatedDigital.Product.Data.Concrete.Entities;
using RelatedDigital.Product.Data.Concrete.Repository;

namespace RelatedDigital.Product.Business.Concrete.Engine
{
  public  class TotalEngine : ITotalService<ProductVM>
    {
        ProductRepository productRepository = new ProductRepository();
        ColorRepository colorRepository = new ColorRepository();
        SizeRepository sizeRepository = new SizeRepository();

        public List<ProductVM> InfoProductWithColor(string color)
        {
            return productRepository.InfoProductWithColor(color);
        }
        public List<ProductVM> GetAll()
        {
            return productRepository.GetAllTotal();
        }
        public List<ProductVM> InfoProductWithSize(string size)
        {
            return productRepository.InfoProductWithSize(size);
        }

      
    }
}
