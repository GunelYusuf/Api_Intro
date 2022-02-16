using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entity;

namespace WebApi.Data.DAL
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }

        //public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
