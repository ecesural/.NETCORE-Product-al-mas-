using System;
using System.Collections.Generic;
using System.Text;
using RelatedDigital.Product.Common.DTO;

namespace RelatedDigital.Product.Common.Concrete.DTO.VM
{
   public class ProductVM
    {
        public ProductsDTO ProductsDTO { get; set; }
        public SizesDTO SizesDTO { get; set; }

        public ColorsDTO ColorsDTO { get; set; }

    }
}
