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
        public void Post([FromBody] string value)
        {

            //return Ok(value.ToString());
            var product = JsonConvert.DeserializeObject<Product>(value);
            _repo.InsertProduct(product);
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
