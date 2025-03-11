using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<ProductsDTO, Products>().ReverseMap();
        CreateMap<(ProductsPostDTO, int), Products>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Item2))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Item1.Name))
            .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Item1.Price)).ReverseMap();
        CreateMap<ProductsPostDTO, Products>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Price));
    }   
}