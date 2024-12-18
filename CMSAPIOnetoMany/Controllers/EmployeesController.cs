using CMSAPIOnetoMany.Interface;
using CMSAPIOnetoMany.Models;
using CMSAPIOnetoMany.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMSAPIOnetoMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _empService;

        public EmployeesController(EmployeeService empservice)
        {
            _empService = empservice;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _empService.GetEmployees();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _empService.GetEmployee(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee emp)
        {
            try
            {
                await _empService.AddEmp(emp);
                return CreatedAtAction(nameof(Get), new { id = emp.empId }, emp);  // Respond with the created employee's ID.
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);  // Handle errors
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee emp)
        {
            if (id != emp.empId)
            {
                return BadRequest("Employee ID mismatch.");
            }

            try
            {
                await _empService.UpdateEmp(emp);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();

        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _empService.DeleteEmp(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
