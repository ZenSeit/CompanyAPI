using AutoMapper;
using CompanyAPI.Dtos;
using CompanyAPI.Models;

namespace CompanyAPI.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyReadDto>();
        CreateMap<CompanyCreateDto, Company>();
    }
}
