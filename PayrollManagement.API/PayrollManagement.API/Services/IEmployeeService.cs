using PayrollManagement.API.Models;

namespace PayrollManagement.API.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>>
        GetEmployees();
    }
}
