using CMSAPIOnetoMany.Models;

namespace CMSAPIOnetoMany.Interface
{
    public interface ICompany
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        Task AddCompany(Company cmp);
        Task DeleteCompany(int id);
        Task UpdateCompany(int id,Company company);
    }
}
