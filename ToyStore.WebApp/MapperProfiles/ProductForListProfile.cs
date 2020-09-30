using AutoMapper;
using ToyStore.Model;
using ToyStore.WebApp.Models;

namespace ToyStore.WebApp.MapperProfiles
{
    /// <summary>
    /// Mapper profile for list products
    /// </summary>
    public class ProductForListProfile : Profile
    {
        public ProductForListProfile()
        {
            CreateMap<Product, ProductForListModel>()
                .ForMember(d => d.Age, opt => opt.MapFrom(s => s.AgeRestriction))
                .ForMember(d => d.Company, opt => opt.MapFrom(s => s.Company))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price));
        }
    }
}