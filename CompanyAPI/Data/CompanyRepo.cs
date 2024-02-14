using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Data;

public class CompanyRepo : ICompanyRepo
{
    private readonly AppDbContext _context;

    public CompanyRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateCompany(Company company)
    {
        if (company == null)
        {
            throw new ArgumentNullException(nameof(company));
        }
        await _context.Companies.AddAsync(company);
    }

    public async Task<IEnumerable<Company>> GetAllCompanies()
    {
        return await _context.Companies.ToListAsync();
    }

    public Task<Company> GetCompanyById(int id) => _context.Companies.FirstOrDefaultAsync(c => c.Id == id);

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

}
