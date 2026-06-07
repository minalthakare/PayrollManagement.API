using Dapper;
using Microsoft.Data.SqlClient;
using PayrollManagement.API.Models;

namespace PayrollManagement.API.Repositories
{


    public class EmployeeRepository :
        IEmployeeRepository
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepository(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Employee>>
        GetEmployees()
        {
            using SqlConnection con =
                new SqlConnection(
                _configuration.GetConnectionString(
                "DefaultConnection"));

            string query =
            @"SELECT *
          FROM Employees";

            return await con.QueryAsync<Employee>(
                query);
        }
    }
}
