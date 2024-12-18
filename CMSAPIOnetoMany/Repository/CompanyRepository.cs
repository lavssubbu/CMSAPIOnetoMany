using CMSAPIOnetoMany.Interface;
using CMSAPIOnetoMany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSAPIOnetoMany.Repository
{
    public class CompanyRepository : ICompany
    {
        private readonly EmpCmpnyContext _context;
       
        public CompanyRepository(EmpCmpnyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _context.Companiess.Include(e=>e.Employees).ToListAsync();
        }
        public async Task<Company> GetCompanyById(int id)
        {
            return await _context.Companiess.Include(e => e.Employees).FirstOrDefaultAsync(e => e.CompId == id) ?? throw new NullReferenceException();
        }
        public async Task AddCompany(Company cmp)
        {
            await _context.Companiess.AddAsync(cmp);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompany(int id)
        {
            // Find the company by ID
            var company = await _context.Companiess.FindAsync(id);
            if (company == null)
            {
                throw new KeyNotFoundException("Company not found");
            }

            // Remove the company from the context
            _context.Companiess.Remove(company);

            // Save changes to the database
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompany(int id, Company company)
        {
            // Find the existing company by ID
            var exiscompany = await _context.Companiess.FirstOrDefaultAsync(c => c.CompId == id);
            if (exiscompany == null)
            {
                throw new KeyNotFoundException("Company not found");
            }
                        
            exiscompany.CompName = company.CompName;
            
            await _context.SaveChangesAsync();
        }
    }
}
