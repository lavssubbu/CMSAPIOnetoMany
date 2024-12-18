using CMSAPIOnetoMany.Interface;
using CMSAPIOnetoMany.Models;

namespace CMSAPIOnetoMany.Service
{
  // From controller - service class - repo class(dbcontext) - Interface
    public class CompanyService
    {
        private readonly ICompany _cmprepo;

        public CompanyService(ICompany cmprepo)
        {
            _cmprepo = cmprepo;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _cmprepo.GetAllCompanies();
        }
        public async Task<Company> GetCompany(int id)
        {
            return await _cmprepo.GetCompanyById(id);
        }
        public async Task AddCmpny(Company cmp)
        {
            await _cmprepo.AddCompany(cmp);
        }

        public async Task DeleteCmpny(int id)
        {
            await _cmprepo.DeleteCompany(id);
        }

        public async Task UpdateCmpny(int id,Company updatedCompany)
        {
            await _cmprepo.UpdateCompany(id,updatedCompany);
        }
    }
}
