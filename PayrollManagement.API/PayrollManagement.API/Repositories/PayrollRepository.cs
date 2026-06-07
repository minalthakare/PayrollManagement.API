namespace PayrollManagement.API.Repositories
{
    using System.Data;
    using Dapper;
    using Microsoft.Data.SqlClient;
    using PayrollManagement.API.Dtos;

    public class PayrollRepository : IPayrollRepository
    {
        private readonly IConfiguration _configuration;

        public PayrollRepository(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task RunPayroll(
    int month,
    int year)
        {
            try
            {
                using SqlConnection con =
                    new SqlConnection(
                    _configuration.GetConnectionString(
                    "DefaultConnection"));

                using SqlCommand cmd =
                    new SqlCommand(
                    "usp_RunPayroll",
                    con);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Month",
                    month);

                cmd.Parameters.AddWithValue(
                    "@Year",
                    year);

                await con.OpenAsync();

                await cmd.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains(
                   "Payroll already generated"))
                {
                    throw new Exception(
                        "DUPLICATE_PAYROLL");
                }

                throw;
            }
        }

        public async Task<IEnumerable<PayrollResponse>>
GetPayroll(
int month,
int year,
int page,
int pageSize)
        {
            using SqlConnection con =
                new SqlConnection(
                    _configuration
                    .GetConnectionString(
                        "DefaultConnection"));

            string query =
            @"
    SELECT
        E.EmployeeId,
        E.EmployeeName,
        P.BasicSalary,
        P.WorkingDays,
        P.DaysPresent,
        P.GrossPay,
        P.PFDeduction,
        P.ProfessionalTax,
        P.NetPay

    FROM PayrollDetails P

    INNER JOIN Employees E
    ON E.EmployeeId=P.EmployeeId

    INNER JOIN PayrollRun R
    ON R.PayrollRunId=P.PayrollRunId

    WHERE
    R.PayrollMonth=@Month
    AND
    R.PayrollYear=@Year

    ORDER BY E.EmployeeId

    OFFSET
    (@Page-1)*@PageSize ROWS

    FETCH NEXT
    @PageSize ROWS ONLY";

            return await con.QueryAsync
            <PayrollResponse>
            (
                query,
                new
                {
                    Month = month,
                    Year = year,
                    Page = page,
                    PageSize = pageSize
                }
            );
        }

        public async Task<PayrollResponse>
GetPayslip(
int runId,
int employeeId)
        {
            using SqlConnection con =
                new SqlConnection(
                _configuration.GetConnectionString(
                "DefaultConnection"));

            string query =
            @"
    SELECT TOP 1
        E.EmployeeId,
        E.EmployeeName,
        P.BasicSalary,
        P.WorkingDays,
        P.DaysPresent,
        P.GrossPay,
        P.PFDeduction,
        P.ProfessionalTax,
        P.NetPay

    FROM PayrollDetails P

    INNER JOIN Employees E
    ON E.EmployeeId=P.EmployeeId

    WHERE
    P.PayrollRunId=@RunId
    AND
    P.EmployeeId=@EmployeeId";

            return await con.QueryFirstOrDefaultAsync
            <PayrollResponse>
            (
                query,
                new
                {
                    RunId = runId,
                    EmployeeId = employeeId
                }
            );
        }
    }
}
