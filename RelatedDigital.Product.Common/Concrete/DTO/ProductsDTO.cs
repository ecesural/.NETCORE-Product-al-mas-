using System;
using System.Collections.Generic;
using System.Text;
using RelatedDigital.Product.Common.Concrete.DTO;

namespace RelatedDigital.Product.Common.DTO
{
  public class ProductsDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        public List<ColorsDTO> Colors { get; set; }
    }
}
