using PayrollManagement.API.Dtos;
using PayrollManagement.API.Repositories;

namespace PayrollManagement.API.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepository _repository;

        public PayrollService(
            IPayrollRepository repository)
        {
            _repository = repository;
        }

        public async Task RunPayroll(
            int month,
            int year)
        {
            await _repository
                .RunPayroll(month, year);
        }

        public async Task<IEnumerable<PayrollResponse>>
GetPayroll(
int month,
int year,
int page,
int pageSize)
        {
            return await _repository
                .GetPayroll(
                    month,
                    year,
                    page,
                    pageSize);
        }

        public async Task<PayrollResponse>
GetPayslip(
int runId,
int employeeId)
        {
            return await _repository
                .GetPayslip(
                    runId,
                    employeeId);
        }
    }
}
