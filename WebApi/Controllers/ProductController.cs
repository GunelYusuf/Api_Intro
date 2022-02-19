using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.DAL;
using WebApi.Data.Entity;
using WebApi.Helper;
using WebApi.Mapper;
using WebApi.ProductDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public ProductController(Context context,IWebHostEnvironment env, IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get(int page = 1)
        {

            var query = _context.Products.AsQueryable();
            var productReturnDto = _mapper.Map<ProductReturnDto>(_context.Products.Skip((page - 1) * 5).Take(5).ToList());
            //ProductReturnDto productReturnDto = new ProductReturnDto
            //{
            //    TotalCount = query.Count(),
            //    Items = query.Skip((page - 1) * 5).Take(5).Select(p => new ProductItemDto
            //    {
            //        Name = p.Name,
            //        IsDelete = p.IsDelete,
            //        Price = p.Price,
            //        CreatedAt = p.CreatedAt,
            //        UpdatedAt = p.UpdatedAt,
            //        Benefit = p.Price - p.CostPrice
            //    }).ToList()
            //};


            return Ok(productReturnDto);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOne(int id)
        {


            ProductReturnDto productReturnDto = new ProductReturnDto();
            productReturnDto.Items = _context.Products.Select(p => new ProductItemDto
            {
                Name = p.Name,
                Price = p.Price,
                IsDelete = p.IsDelete,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                Benefit=p.Price-p.CostPrice
            }).ToList();
           

            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(404);
            product.ImageUrl = Path.Combine(_env.WebRootPath, "Images/Product", product.ImageUrl);
            return StatusCode(200, product);
        }

        [HttpPost]
        public IActionResult Create([FromForm]ProductCreateDto productCreateDto)
        {
            if (!(productCreateDto.Photo.IsImage()&& productCreateDto.Photo.MaxLength(700)))
            {
                return BadRequest("Please,choose normal photo");
            }
            string url = _env.ContentRootPath;
            string fileName = productCreateDto.Photo.SaveImg(_env.ContentRootPath,"Images/Product").Result;
            Product newProduct = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price,
                ImageUrl = fileName,
                IsDelete = productCreateDto.IsDelete
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductUpdateDto productUpdateDto)
        {
            Product dbProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbProduct == null) return NotFound();
            dbProduct.Name = productUpdateDto.Name;
            dbProduct.Price = productUpdateDto.Price;
            dbProduct.IsDelete = productUpdateDto.IsDelete;
            _context.SaveChanges();
            return StatusCode(200);
        }

        [HttpDelete("{id}")]

        public IActionResult Remove(int? id)
        {
            if (id == null) return NotFound();

            Product dbProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbProduct == null) return NotFound();

            _context.Remove(dbProduct);
            _context.SaveChanges();

            return NoContent();

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
        public IActionResult GetOnee(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(404);

            return StatusCode(200, product);
        }

     

        [HttpPost]

        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, Product product)
        {
            if (id == null) return NotFound();
            Product dbProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbProduct == null) return NotFound();
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            _context.SaveChanges();
            return StatusCode(200);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Product dbProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbProduct == null) return NotFound();
            _context.Products.Remove(dbProduct);
            _context.SaveChanges();
            return StatusCode(202);
        }

    }
}
