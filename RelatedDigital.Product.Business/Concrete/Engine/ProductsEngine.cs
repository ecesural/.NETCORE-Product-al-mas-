using System;
using System.Collections.Generic;
using System.Text;
using RelatedDigital.Product.Business.Interfaces;
using RelatedDigital.Product.Common.Concrete.DTO.VM;
using RelatedDigital.Product.Common.DTO;
using RelatedDigital.Product.Data.Concrete.Entities;
using RelatedDigital.Product.Data.Concrete.Repository;

namespace RelatedDigital.Product.Business.Engine
{
  public  class ProductsEngine : IProductsService<ProductsDTO>
    {
        ProductRepository productRepository = new ProductRepository();
        ColorRepository colorRepository = new ColorRepository();
        SizeRepository sizeRepository = new SizeRepository();

        public List<ProductVM> InfoProductWithColor(string color)
        {
            return productRepository.InfoProductWithColor(color);
        }

        public List<ProductVM> InfoProductWithSize(string size)
        {
            return productRepository.InfoProductWithSize(size);
        }

        public List<ProductVM> InfoProductWithSizeColor(string size,string color)
        {
            return productRepository.InfoProductWithSizeColor(size, color);
        }
        public ProductVM GetByIdProducts(int id)
        {
            return productRepository.GetByIdProducts(id);
        }

        public List<ProductVM> GetByNameProducts(string name)
        {
            return productRepository.GetByNameProducts(name);
        }

        public Products GetById(int id)
        {           
                return productRepository.GetById(id);           
        }

        public void DeleteProducts(int id)
        {
           productRepository.Remove(id);
        }


        public bool SoftDeleteProducts(int id)
        {
            Products _products = GetById(id);
            _products.IsActive =false;
           
            try
            {
                productRepository.SoftDelete(_products);
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }
        public bool UpdateProducts(int id,Products products)
        {
            Products _products = GetById(id);
            _products.Name = products.Name;
            _products.Price = products.Price;
            _products.IsActive = products.IsActive;
            try
            {
                productRepository.Update(_products);
                return true;
            }
            catch (Exception)
            {
                return false;
            }             
        }
        public Products AddProducts(Products products)
        {
            Products _products = new Products();
            _products.Name = products.Name;
            _products.Price = products.Price;
            _products.IsActive = products.IsActive;


            return productRepository.AddProductReturn(_products);
        }
        public Total AddProductsTotal(Total products)
        {
            Products _products = new Products();
            Colors _colors = new Colors();
            Size _size = new Size();



            _products.IsActive = products.Products.IsActive;
            _products.Name = products.Products.Name;
            _products.Price = products.Products.Price;
            productRepository.Add(_products);

            _colors.ProductsProductId = _products.ProductId;


            _colors.color =products.Colors.color;

            colorRepository.Add(_colors);

            _size.ColorsId = _colors.Id;

            _size.Sizes = products.Size.Sizes;

            sizeRepository.Add(_size);

            Total total = new Total();

            total.Products = _products;
            total.Size = _size;
            total.Colors = _colors;

            return total;
        }


        public IEnumerable<ProductsDTO> GetAll()
        {
            return productRepository.GetAllProducts();
        }
    }
}
