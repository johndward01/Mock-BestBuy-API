using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
