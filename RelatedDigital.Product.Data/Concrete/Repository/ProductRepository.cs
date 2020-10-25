using System;
using System.Collections.Generic;
using RelatedDigital.Product.Data.Concrete.Entities;
using RelatedDigital.Product.Data.Interfaces;
using RelatedDigital.Product.Data.Concrete.Contexts;
using System.Linq;
using RelatedDigital.Product.Common.DTO;
using RelatedDigital.Product.Common.Concrete.DTO.VM;
using RelatedDigital.Product.Common.Concrete.DTO;

namespace RelatedDigital.Product.Data.Concrete.Repository
{
    public class ProductRepository : IRepository<Products>
    {
        //public RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
        public IEnumerable<ProductsDTO> GetAllProducts()
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            List<ProductsDTO> products = relatedDigitalContext.Products

                            .Select(x => new ProductsDTO
                            {
                                ProductId = x.ProductId,
                                Name = x.Name,
                                Price = x.Price,
                                IsActive = x.IsActive
                            }).ToList();
            return products;

        }
        public List<ProductVM> GetAllTotal()
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            var query = (from p in relatedDigitalContext.Products
                         join c in relatedDigitalContext.Colors on p.ProductId equals c.ProductsProductId
                         join s in relatedDigitalContext.Sizes on c.Id equals s.ColorsId


                         select (new ProductVM()
                         {
                             ColorsDTO = new ColorsDTO()
                             {
                                 color = c.color,
                                 ProductsProductId = c.ProductsProductId,
                                 Id = c.Id
                             },
                             SizesDTO = new SizesDTO()
                             {
                                 Size = s.Sizes,
                                 ColorsId = s.ColorsId,
                                 Id = s.Id


                             },
                             ProductsDTO = new ProductsDTO()
                             {
                                 Price = p.Price,
                                 Name = p.Name,
                                 ProductId = p.ProductId,
                                 IsActive = p.IsActive,
                           
                             }
                         })).ToList();
            return query;
        }
        public List<ProductVM> InfoProductWithColor(string color)
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            var query = (from p in relatedDigitalContext.Products
                         join c in relatedDigitalContext.Colors on p.ProductId equals c.ProductsProductId
                         join s in relatedDigitalContext.Sizes on c.Id equals s.ColorsId

                         where (c.color == color)
                         select (new ProductVM()
                         {
                             ColorsDTO = new ColorsDTO()
                             {
                                 color = c.color,
                                 ProductsProductId = c.ProductsProductId,
                                 Id = c.Id
                             },
                             SizesDTO = new SizesDTO()
                             {
                                 Size = s.Sizes,
                                 ColorsId = s.ColorsId,
                                 Id = s.Id


                             },
                             ProductsDTO = new ProductsDTO()
                             {
                                 Price = p.Price,
                                 Name = p.Name,
                                 ProductId = p.ProductId,
                                 IsActive = p.IsActive
                             }
                         })).ToList();
            return query;
        }

        public List<ProductVM> InfoProductWithSize(string size)
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            var query = (from p in relatedDigitalContext.Products
                         join c in relatedDigitalContext.Colors on p.ProductId equals c.ProductsProductId
                         join s in relatedDigitalContext.Sizes on c.Id equals s.ColorsId

                         where (s.Sizes == size)
                         select (new ProductVM()
                         {
                             ColorsDTO = new ColorsDTO()
                             {
                                 color = c.color,
                                 ProductsProductId = c.ProductsProductId,
                                 Id = c.Id
                             },
                             SizesDTO = new SizesDTO()
                             {
                                 Size = s.Sizes,
                                 ColorsId = s.ColorsId,
                                 Id = s.Id


                             },
                             ProductsDTO = new ProductsDTO()
                             {
                                 Price = p.Price,
                                 Name = p.Name,
                                 ProductId = p.ProductId,
                                 IsActive = p.IsActive
                             }
                         })).ToList();
            return query;
        }

        public List<ProductVM> InfoProductWithSizeColor(string size,string color)
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            var query = (from p in relatedDigitalContext.Products
                         join c in relatedDigitalContext.Colors on p.ProductId equals c.ProductsProductId
                         join s in relatedDigitalContext.Sizes on c.Id equals s.ColorsId

                         where (s.Sizes == size && c.color== color)
                         select (new ProductVM()
                         {
                             ColorsDTO = new ColorsDTO()
                             {
                                 color = c.color,
                                 ProductsProductId = c.ProductsProductId,
                                 Id = c.Id
                             },
                             SizesDTO = new SizesDTO()
                             {
                                 Size = s.Sizes,
                                 ColorsId = s.ColorsId,
                                 Id = s.Id


                             },
                             ProductsDTO = new ProductsDTO()
                             {
                                 Price = p.Price,
                                 Name = p.Name,
                                 ProductId = p.ProductId,
                                 IsActive = p.IsActive
                             }
                         })).ToList();
            return query;
        }
        public void Add(Products entity)
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            relatedDigitalContext.Products.Add(entity);
            relatedDigitalContext.SaveChanges();
            
        }

        public Products AddProductReturn(Products entity)
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            relatedDigitalContext.Products.Add(entity);
            relatedDigitalContext.SaveChanges();
            return entity;
        }
        public Products GetById(int id)
        {
            using (RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext())
            {
                return relatedDigitalContext.Products.Find(id);
            }
        }
        public ProductVM GetByIdProducts(int id)
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            var query = (from p in relatedDigitalContext.Products
                         join c in relatedDigitalContext.Colors on p.ProductId equals c.ProductsProductId
                         join s in relatedDigitalContext.Sizes on c.Id equals s.ColorsId

                         where (p.ProductId == id)
                         select (new ProductVM()
                         {
                             ColorsDTO = new ColorsDTO()
                             {
                                 color = c.color,
                                 ProductsProductId = c.ProductsProductId,
                                 Id = c.Id
                             },
                             SizesDTO = new SizesDTO()
                             {
                                 Size = s.Sizes,
                                 ColorsId = s.ColorsId,
                                 Id = s.Id


                             },
                             ProductsDTO = new ProductsDTO()
                             {
                                 Price = p.Price,
                                 Name = p.Name,
                                 ProductId = p.ProductId,
                                 IsActive = p.IsActive
                             }
                         })).FirstOrDefault();
            return query;
        }
      
        public List<ProductVM> GetByNameProducts(string name)
        {
            using RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext();
            var query = (from p in relatedDigitalContext.Products
                         join c in relatedDigitalContext.Colors on p.ProductId equals c.ProductsProductId
                         join s in relatedDigitalContext.Sizes on c.Id equals s.ColorsId

                         where (p.Name == name)
                         select (new ProductVM()
                         {
                             ColorsDTO = new ColorsDTO()
                             {
                                 color = c.color,
                                 ProductsProductId = c.ProductsProductId,
                                 Id = c.Id
                             },
                             SizesDTO = new SizesDTO()
                             {
                                 Size = s.Sizes,
                                 ColorsId = s.ColorsId,
                                 Id = s.Id


                             },
                             ProductsDTO = new ProductsDTO()
                             {
                                 Price = p.Price,
                                 Name = p.Name,
                                 ProductId = p.ProductId,
                                 IsActive = p.IsActive
                             }
                         })).ToList();
            return query;
        }

        public void Remove(int id)
        {
            using var relatedDigitalContext = new RelatedDigitalContext();
            var deleteProduct = GetById(id);
            relatedDigitalContext.Products.Remove(deleteProduct);
            relatedDigitalContext.SaveChanges();

        }

        public bool SoftDelete(Products entity)
        {
            using (RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext())
            {

                relatedDigitalContext.Products.Attach(entity);
                var entry = relatedDigitalContext.Entry(entity);
                entry.Property(x => x.IsActive).IsModified = true;
               
                try
                {
                    relatedDigitalContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool Update(Products entity)
        {
            using (RelatedDigitalContext relatedDigitalContext = new RelatedDigitalContext())
            {

                relatedDigitalContext.Products.Attach(entity);
                var entry = relatedDigitalContext.Entry(entity);
                entry.Property(x => x.Name).IsModified = true;
                entry.Property(x => x.Price).IsModified = true;
                entry.Property(x => x.IsActive).IsModified = true;
                try
                {
                    relatedDigitalContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
