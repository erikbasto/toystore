using AutoMapper;
using ToyStore.Model;
using ToyStore.WebApp.Models;

namespace ToyStore.WebApp.MapperProfiles
{
    /// <summary>
    /// Mapper profile for new products
    /// </summary>
    public class NewProductProfile : Profile
    {
        public NewProductProfile()
        {
            CreateMap<NewProductModel, Product>()
                .ForMember(d => d.AgeRestriction, opt => opt.MapFrom(s => s.AgeRestriction))
                .ForMember(d => d.Company, opt => opt.MapFrom(s => s.Company))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price));
        }
    }
}
