using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RelatedDigital.Product.Data.Concrete.Entities
{
    [Serializable]
    [Table("Products")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [StringLength(150)]
        public string Name { get; set; }      
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        public List<Colors> Colors { get; set; }



    }
}
