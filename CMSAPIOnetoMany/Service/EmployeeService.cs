using CMSAPIOnetoMany.Interface;
using CMSAPIOnetoMany.Models;

namespace CMSAPIOnetoMany.Service
{
    public class EmployeeService
    {
        private readonly IEmployee _emprepo;

        public EmployeeService(IEmployee emprepo)
        {
            _emprepo = emprepo;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _emprepo.GetAllEmployees();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _emprepo.GetEmployeeById(id);
        }
        public async Task AddEmp(Employee em)
        {
            await _emprepo.AddEmployee(em);
        }

        public async Task UpdateEmp(Employee emp)
        {
            var existingEmployee = await _emprepo.GetEmployeeById(emp.empId);
            if (existingEmployee != null)
            {
                await _emprepo.UpdateEmpAsync(emp);
            }
            else
            {
                throw new KeyNotFoundException($"Employee with ID {emp.empId} not found.");
            }
        }

        // New method for deleting an employee
        public async Task DeleteEmp(int id)
        {
            var employee = await _emprepo.GetEmployeeById(id);
            if (employee != null)
            {
                await _emprepo.DeleteEmpAsync(id);
            }
            else
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
        }


    }
}
