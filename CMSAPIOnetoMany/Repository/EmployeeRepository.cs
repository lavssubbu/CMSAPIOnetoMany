using CMSAPIOnetoMany.Interface;
using CMSAPIOnetoMany.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CMSAPIOnetoMany.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmpCmpnyContext _context;

        public EmployeeRepository(EmpCmpnyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Include(c=>c.Company).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.empId == id) ?? throw new NullReferenceException();
        }

        public async Task AddEmployee(Employee emp)
        {
            try
            {
                _context.Employees.Add(emp);
                await _context.SaveChangesAsync();  
            }
            catch (Exception ex)
            {
               
                throw new Exception("Error adding employee", ex);
            }
        }

        public async Task UpdateEmpAsync(Employee emp)
        {
            var existingEmployee = await _context.Employees.FindAsync(emp.empId);
            if (existingEmployee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            // Update employee fields
            existingEmployee.empName = emp.empName;
            existingEmployee.empSal = emp.empSal;
            existingEmployee.JoiningDate = emp.JoiningDate;

            _context.Employees.Update(existingEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmpAsync(int id)
        {
            var employee = await GetEmployeeById(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

    }
}
