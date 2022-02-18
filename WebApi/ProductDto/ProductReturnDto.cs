using System;
using System.Collections.Generic;

namespace WebApi.ProductDto
{
    public class ProductReturnDto
    {
        public int TotalCount { get; set; }

        public List<ProductItemDto> Items { get; set; }

        public ProductReturnDto()
        {
            Items = new List<ProductItemDto>();
        }
    }
}
