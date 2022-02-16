using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.DAL;
using WebApi.Data.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly Context _context;

        public CategoryController(Context context)
        {
            _context = context;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<Category> Get()
        {
            return _context.Categories.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOne(int id)
        {
            if (id == null) return NotFound();
            Category dbCategory = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (dbCategory == null) return StatusCode(404);

            return StatusCode(200, dbCategory);
        }


        [HttpPost]

        public IActionResult Create(Category category)
        {
            bool isExist = _context.Categories.Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if (isExist)
            {
               return StatusCode(401);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return StatusCode(201);
        }

        public IActionResult Update(int? id,string name)
        {
            if (id == null) return NotFound();
            Category dbCategory = _context.Categories.Find(id);
            if (dbCategory == null) return NotFound();
            return StatusCode(200, dbCategory);
        }

        [HttpPut ("{id}")]
        public IActionResult Update(Category category)
        {
            if (!ModelState.IsValid) return View();
            bool isExist = _context.Categories.Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            Category isExistCategory = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (isExist && (isExistCategory.Name.ToLower() == category.Name.ToLower().Trim()))
            {
               return StatusCode(401);
            }
            {
                isExistCategory.Name = category.Name;
                isExistCategory.Description = category.Description;
                _context.SaveChanges();

                return StatusCode(200);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Category dbCategory = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (dbCategory == null) return NotFound();
            _context.Categories.Remove(dbCategory);
            _context.SaveChanges();
            return StatusCode(202);
        }

    }
}
