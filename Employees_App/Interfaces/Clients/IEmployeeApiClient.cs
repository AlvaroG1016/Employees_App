using Employees_App.Models.DTO;

namespace Employees_App.Interfaces.Clients
{
    public interface IEmployeeApiClient
    {
        Task<List<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
    }
}
