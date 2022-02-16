using System;
namespace WebApi.ProductDto
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsDelete { get; set; }
    }
}
