using Application.VM;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Applications.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        { 
        CreateMap<Compra, CompraIndexVM>().ReverseMap();
            CreateMap<Compra, CompraCreateVM>().ReverseMap();
        }
    }
}
