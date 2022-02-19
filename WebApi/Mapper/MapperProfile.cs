using System;
using AutoMapper;
using WebApi.Data.Entity;
using WebApi.ProductDto;

namespace WebApi.Mapper
{
    public class MapperProfile:Profile
    {
        private static string localhost = "https://localhost:5001";

        public MapperProfile()
        {
            CreateMap<Product, ProductItemDto>()

                .ForMember(p => p.LocationUrl, src => src.MapFrom(p => localhost + p.ImageUrl))
                .ForMember(p => p.Benefit, src => src.MapFrom(p => p.Price - p.CostPrice));

            CreateMap<Product, ProductReturnDto>();

                
        }
    }
}
