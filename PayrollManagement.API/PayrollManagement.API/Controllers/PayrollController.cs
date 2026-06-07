using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollManagement.API.Dtos;
using PayrollManagement.API.Services;

namespace PayrollManagement.API.Controllers
{
    [ApiController]
    [Route("api/payroll")]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _service;

        public PayrollController(
            IPayrollService service)
        {
            _service = service;
        }

        [HttpPost("run")]
        public async Task<IActionResult>
RunPayroll(
    PayrollRequest request)
        {
            try
            {
                await _service.RunPayroll(
                    request.Month,
                    request.Year);

                return Created(
                    "",
                    "Payroll Generated");
            }
            catch (Exception ex)
            {
                if (ex.Message ==
                    "DUPLICATE_PAYROLL")
                {
                    return Conflict(
                        "Payroll already exists for this month and year");
                }

                return StatusCode(
                    500,
                    ex.Message);
            }
        }

        [HttpGet("{month}/{year}")]
        public async Task<IActionResult>
GetPayroll(
int month,
int year,
int page = 1,
int pageSize = 5)
        {
            var result =
                await _service.GetPayroll(
                    month,
                    year,
                    page,
                    pageSize);

            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{runId}/slip/{employeeId}")]
        public async Task<IActionResult>
GetPayslip(
int runId,
int employeeId)
        {
            var result =
                await _service.GetPayslip(
                    runId,
                    employeeId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
