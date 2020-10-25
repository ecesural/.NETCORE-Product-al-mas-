using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RelatedDigital.Product.Data.Concrete.Entities;

namespace RelatedDigital.Product.Data.Concrete.Contexts
{
    public class RelatedDigitalContext: DbContext
    {

        public DbSet<Products> Products { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=DBRelatedDigitalll;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=true");
        }


    }
}
