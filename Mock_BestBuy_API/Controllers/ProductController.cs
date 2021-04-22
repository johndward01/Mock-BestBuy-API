using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mock_BestBuy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult <IEnumerable<Product>> GetAllProducts()
        {
            var products = _repo.GetProducts();
            return Ok(JsonConvert.SerializeObject(products));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult <Product> Get(int id)
        {
            var product = _repo.GetProduct(id);            
            return Ok(JsonConvert.SerializeObject(product));
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post(Product product)
        {
            var lastProductId = _repo.GetProducts().LastOrDefault().ProductID; // In order to Insert we need a ProductID
            product.ProductID = ++lastProductId; // and since it defaults to 0 we must get the last 1 and then (++it)
            _repo.InsertProduct(product);
        }
       

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, Product product)
        {
            //var productToUpdate = _repo.GetProduct(id);
            product.ProductID = id;
            _repo.UpdateProduct(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var productToDelete = _repo.GetProduct(id);
            _repo.DeleteProduct(productToDelete);
        }
    }
}
