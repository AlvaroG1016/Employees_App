using Employees_App.Models.DTO;

namespace Employees_App.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeWithAnnualSalaryDto>> GetAllAsync();
        Task<EmployeeWithAnnualSalaryDto> GetByIdAsync(int id);
    }
}
