using System;
using WebApi.Data.Entity;

namespace WebApi.ProductDto
{
    public class ProductItemDto
    {

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Benefit { get; set; }

        public string LocationUrl { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
