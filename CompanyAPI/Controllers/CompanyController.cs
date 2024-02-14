using AutoMapper;
using CompanyAPI.Data;
using CompanyAPI.Dtos;
using CompanyAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController: ControllerBase
{
    private readonly ICompanyRepo _repository;
    private readonly IMapper _mapper;

    public CompanyController(ICompanyRepo repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyReadDto>>> GetAllCompanies()
    {
        var companyItems = await _repository.GetAllCompanies();
        return Ok(_mapper.Map<IEnumerable<CompanyReadDto>>(companyItems));
    }

    [HttpGet("{id}", Name = "GetCompanyById")]
    public async Task<ActionResult<CompanyReadDto>> GetCompanyById(int id)
    {
        var companyItem = await _repository.GetCompanyById(id);
        if (companyItem != null)
        {
            return Ok(_mapper.Map<CompanyReadDto>(companyItem));
        }
        return NotFound();
    }

    [HttpPost]
    public async  Task<ActionResult<CompanyReadDto>> CreateCompany(CompanyCreateDto companyCreateDto)
    {
        var companyModel = _mapper.Map<Company>(companyCreateDto);
        await _repository.CreateCompany(companyModel);
        await _repository.SaveChanges();

        var companyReadDto = _mapper.Map<CompanyReadDto>(companyModel);

        return CreatedAtRoute(nameof(GetCompanyById), new { Id = companyReadDto.Id }, companyReadDto);
    }


}
