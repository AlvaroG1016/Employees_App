using Dropi_Dev.Utilities;
using Employees_App.Interfaces.Services;
using Employees_App.Models.CustomResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employees_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> GetAll()
        {
            try
            {
            var employees = await _employeeService.GetAllAsync();
            return Ok(ResponseBuilder.BuildSuccessResponse(employees));

            }catch(Exception ex)
            {
                return BadRequest(ResponseBuilder.BuildErrorResponse(ex.Message));

            }
        }
    }
}
