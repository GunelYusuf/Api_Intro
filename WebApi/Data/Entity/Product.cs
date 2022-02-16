using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entity
{
    public class Product:BaseEntity
    {
       [Required(ErrorMessage = "don't leave empty")]
        public string Name { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
