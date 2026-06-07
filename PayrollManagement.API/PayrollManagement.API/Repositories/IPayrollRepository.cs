using PayrollManagement.API.Dtos;

namespace PayrollManagement.API.Repositories
{
    public interface IPayrollRepository
    {
        Task RunPayroll(int month, int year);

        Task<IEnumerable<PayrollResponse>>
     GetPayroll(
         int month,
         int year,
         int page,
         int pageSize);

        Task<PayrollResponse>
GetPayslip(
int runId,
int employeeId);
    }
}
