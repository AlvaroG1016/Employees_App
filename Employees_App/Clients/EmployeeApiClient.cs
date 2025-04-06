using Employees_App.Interfaces.Clients;
using Employees_App.Models.CustomResponses;
using Employees_App.Models.DTO;

namespace Employees_App.Clients
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<EmployeeDto>>>("employees");
            return response?.Data ?? new List<EmployeeDto>();
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<EmployeeDto>>($"employee/{id}");
            return response?.Data;
        }
    }
}
