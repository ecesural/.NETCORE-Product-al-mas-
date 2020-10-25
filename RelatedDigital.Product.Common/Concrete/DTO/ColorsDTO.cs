using System;
using System.Collections.Generic;
using System.Text;

namespace RelatedDigital.Product.Common.Concrete.DTO
{
   public class ColorsDTO
    {
        public int Id { get; set; }
        public string color { get; set; }
        public int ProductsProductId { get; set; }

        public List<SizesDTO> Sizes { get; set; }

    }
}
