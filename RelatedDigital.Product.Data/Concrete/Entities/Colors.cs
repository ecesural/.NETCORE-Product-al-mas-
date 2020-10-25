using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RelatedDigital.Product.Data.Concrete.Entities
{

    [Serializable]
    [Table("Colors")]
    public  class Colors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(150)]
        public string color { get; set; }

        public int ProductsProductId { get; set; }

        public List<Size> Sizes { get; set; }



    }
}
