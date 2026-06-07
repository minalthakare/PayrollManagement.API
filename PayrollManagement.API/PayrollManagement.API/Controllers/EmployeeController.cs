using Microsoft.AspNetCore.Mvc;
using PayrollManagement.API.Services;

namespace PayrollManagement.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(
            IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var result =
                await _service.GetEmployees();

            return Ok(result);
        }
    }
}