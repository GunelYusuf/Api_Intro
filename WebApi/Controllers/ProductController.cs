using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        public static List<Product> products = new List<Product> {
            new Product { Id = 1, Name = "blauzer", Price = 250 },
            new Product { Id = 2, Name = "skirt", Price = 340 },
            new Product { Id = 3, Name = "body", Price = 700 } };

        // GET: api/values
        [HttpGet]
        public List<Product> Get()
        {
            return products;
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(404);

            return StatusCode(200,product) ;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
