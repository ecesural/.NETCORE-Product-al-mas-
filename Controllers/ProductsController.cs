using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelatedDigital.Product.Business.Concrete.Engine;
using RelatedDigital.Product.Business.Engine;
using RelatedDigital.Product.Common.Concrete.DTO.VM;
using RelatedDigital.Product.Common.DTO;
using RelatedDigital.Product.Data.Concrete.Entities;

namespace RelatedDigital.Product.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        TotalEngine TotalEngine = new TotalEngine();
        ProductsEngine productsEngine = new ProductsEngine();
 

        [HttpGet]
        [Route("[action]")]
        public IActionResult  GetProducts()       
        {          
            return Ok( productsEngine.GetAll());            
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetTotal()
        {
            return Ok(TotalEngine.GetAll());
        }

        [HttpGet]
        [Route("[action]/{color}")]
        [Route("{name:alpha}")]
        public IActionResult GetInfoProductWithColor(string color)

        {
            return Ok(TotalEngine.InfoProductWithColor(color));
        }


        [HttpGet]
        [Route("[action]/{size}")]

        [Route("{name:alpha}")]
        public IActionResult GetInfoProductWithSize(string size)

        {
            return Ok(TotalEngine.InfoProductWithSize(size));
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetByIdProducts(int id)
        {
            ProductVM products = productsEngine.GetByIdProducts(id);

            if (products == null)
            {
                return NotFound("The Products record couldn't be found.");
            }

            return Ok(products);
        }


        [HttpGet]
        [Route("[action]/{name}")]

        [Route("{name:alpha}")]
        public IActionResult GetByNameProducts(string name)
        {
           List<ProductVM>products = productsEngine.GetByNameProducts(name);

            if (products == null)
            {
                return NotFound("The Products record couldn't be found.");
            }

            return Ok(products);
        }
        [HttpGet]
        [Route("[action]/{size}/{color}")]

        [Route("{name:alpha}")]
        public IActionResult GetInfoProductWithSizeColor(string size,string color)
        {
            List<ProductVM> products = productsEngine.InfoProductWithSizeColor(size, color);

            if (products == null)
            {
                return NotFound("The Products record couldn't be found.");
            }

            return Ok(products);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostProducts([FromBody] Products products)
        {
            if (products == null)
            {
                return BadRequest("Products is null.");
            }

            Products _products = productsEngine.AddProducts(products);
            return CreatedAtAction("GetProducts", new { id = _products.ProductId }, _products);


        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostTotalProducts([FromBody] Total products)
        {
            if (products == null)
            {
                return BadRequest("Products is null.");
            }

            Total _products = productsEngine.AddProductsTotal(products);
            return CreatedAtAction("GetProducts", new {}, _products);


        }

        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public IActionResult PutProducts(int id, [FromBody] Products products)
        {
            if (products == null)
            {
                return BadRequest("Products is null.");
            }

            Products productstoUpdate = productsEngine.GetById(id);
            if (productstoUpdate == null)
            {
                return NotFound("The Products record couldn't be found.");
            }

            productsEngine.UpdateProducts(id,products);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducts(int id)
        {
            Products products = productsEngine.GetById(id);
            if (products == null)
            {
                return NotFound("The Products record couldn't be found.");
            }

            productsEngine.DeleteProducts(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public IActionResult SoftDeleteProducts(int id)
        {
            Products products = productsEngine.GetById(id);
            if (products == null)
            {
                return NotFound("The Products record couldn't be found.");
            }
            productsEngine.SoftDeleteProducts(id);
            return NoContent();
        }

    }
}