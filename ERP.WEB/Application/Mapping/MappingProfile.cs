using Application.VM;
using AutoMapper;
using Domain;

namespace Applications.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        { 
        CreateMap<Produto, ProdutoIndexVM>().ReverseMap();
            CreateMap<Produto, ProdutoCreateVM>().ReverseMap();
        }
    }
}
