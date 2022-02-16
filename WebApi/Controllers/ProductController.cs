using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.DAL;
using WebApi.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }

       [HttpGet]
       public IActionResult Get()
        {
            List<Product> product = _context.Products.Include(c => c.Category).Take(3).ToList();
            return StatusCode(200, product);
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(404);

            return StatusCode(200, product);
        }

        //[HttpPost]

        //public IActionResult Create(Product product)
        //{
        //    _context.Products.Add(product);
        //    _context.SaveChanges();
        //    return StatusCode(201);
        //}

        //[HttpPut ("{id}")]

        //public IActionResult Update(int id,Product product)
        //{
        //    if (id==null) return NotFound();
        //    Product dbProduct = _context.Products.FirstOrDefault(p => p.Id == id);
        //    if (dbProduct == null) return NotFound();
        //    dbProduct.Name = product.Name;
        //    dbProduct.Price = product.Price;
        //    _context.SaveChanges();
        //    return StatusCode(200);
        //}

        //[HttpDelete("{id}")]

        //public IActionResult Delete(int id)
        //{
        //    if (id == null) return NotFound();
        //    Product dbProduct = _context.Products.FirstOrDefault(p => p.Id == id);
        //    if (dbProduct == null) return NotFound();
        //    _context.Products.Remove(dbProduct);
        //    _context.SaveChanges();
        //    return StatusCode(202);
        //}

    }
}
