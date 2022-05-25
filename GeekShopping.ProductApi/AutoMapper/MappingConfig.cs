using AutoMapper;
using GeekShopping.ProductApi.Models;
using GeekShopping.ProductApi.ValueObjects;

namespace GeekShopping.ProductApi.AutoMapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
