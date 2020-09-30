using AutoMapper;
using ToyStore.Model;
using ToyStore.WebApp.Models;

namespace ToyStore.WebApp.MapperProfiles
{
    /// <summary>
    /// Mapper profiule for  products update
    /// </summary>
    public class UpdateProductProfile : Profile
    {
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductModel, Product>()
                .ForMember(d => d.AgeRestriction, opt => opt.MapFrom(s => s.Age))
                .ForMember(d => d.Company, opt => opt.MapFrom(s => s.Company))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price));
        }
    }
}