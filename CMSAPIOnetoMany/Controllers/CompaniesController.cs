using CMSAPIOnetoMany.Interface;
using CMSAPIOnetoMany.Models;
using CMSAPIOnetoMany.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMSAPIOnetoMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyService _cmpService;

        public CompaniesController(CompanyService cmpservice)
        {
            _cmpService = cmpservice;
        }

      
        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return await _cmpService.GetCompanies();
        }

        
        // GET: api/<CompaniesController>
        

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public async Task<Company> Get(int id)
        {
            return await _cmpService.GetCompany(id);
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Company cmp)
        {
            if (cmp == null)
            {
                return BadRequest("Invalid company data");
            }
             await _cmpService.AddCmpny(cmp);
                      
            return Ok(new { message = "Company Added Successfully", company = cmp });
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Company updatedCompany)
        {
            if (updatedCompany == null || id != updatedCompany.CompId)
            {
                return BadRequest("Company data is invalid or IDs do not match");
            }

            try
            {
                await _cmpService.UpdateCmpny(id,updatedCompany);
                return Ok(new { message = "Company Updated Successfully", company = updatedCompany });
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                return StatusCode(500, new { message = "An error occurred while updating the company", error = ex.Message });
            }
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cmpService.DeleteCmpny(id);
                return Ok(new { message = "Company Deleted Successfully" });
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                return StatusCode(500, new { message = "An error occurred while deleting the company", error = ex.Message });
            }

        }
    }
}
