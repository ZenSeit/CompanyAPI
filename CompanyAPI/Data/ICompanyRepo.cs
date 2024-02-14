using CompanyAPI.Models;

namespace CompanyAPI.Data;

public interface ICompanyRepo
{
    Task SaveChanges();
    Task<IEnumerable<Company>> GetAllCompanies();
    Task<Company> GetCompanyById(int id);
    Task CreateCompany(Company company);
}
