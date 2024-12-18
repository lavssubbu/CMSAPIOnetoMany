using CMSAPIOnetoMany.Models;

namespace CMSAPIOnetoMany.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmpAsync(Employee emp);
        Task DeleteEmpAsync(int id);
    }
}
