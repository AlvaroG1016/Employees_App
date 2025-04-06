using AutoMapper;
using Employees_App.Interfaces.Clients;
using Employees_App.Interfaces.Services;
using Employees_App.Models.DTO;

namespace Employees_App.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeApiClient _apiClient;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public async Task<List<EmployeeWithAnnualSalaryDto>> GetAllAsync()
        {
            var employees = await _apiClient.GetAllEmployeesAsync();
            return _mapper.Map<List<EmployeeWithAnnualSalaryDto>>(employees);
        }

        public async Task<EmployeeWithAnnualSalaryDto> GetByIdAsync(int id)
        {
            var employee = await _apiClient.GetEmployeeByIdAsync(id);
            if (employee == null)
                throw new KeyNotFoundException($"Employee with id {id} not found.");

            return _mapper.Map<EmployeeWithAnnualSalaryDto>(employee);
        }
    }
}
