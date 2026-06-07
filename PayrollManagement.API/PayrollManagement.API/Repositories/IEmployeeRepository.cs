using PayrollManagement.API.Models;

namespace PayrollManagement.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>>
        GetEmployees();
    }
}
