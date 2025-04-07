using AutoMapper;
using Employees_App.Interfaces.Clients;
using Employees_App.Models.DTO;
using Employees_App.Services;
using Moq;
using Xunit;

namespace Employees_App.Tests
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeApiClient> _mockApiClient;
        private readonly Mock<IMapper> _mockMapper;
        private readonly EmployeeService _service;

        public EmployeeServiceTests()
        {
            _mockApiClient = new Mock<IEmployeeApiClient>();
            _mockMapper = new Mock<IMapper>();
            _service = new EmployeeService(_mockApiClient.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedEmployees()
        {
            // Arrange
            var employeeDtos = new List<EmployeeDto>
            {
                new EmployeeDto { Id = 1,  Employee_Name= "Alvaro", Employee_Salary = 5000 }
            };

            var mappedDtos = new List<EmployeeWithAnnualSalaryDto>
            {
                new EmployeeWithAnnualSalaryDto { Id = 1, Employee_Name = "Alvaro", Employee_Annual_Salary = 60000 }
            };

            _mockApiClient.Setup(x => x.GetAllEmployeesAsync()).ReturnsAsync(employeeDtos);
            _mockMapper.Setup(m => m.Map<List<EmployeeWithAnnualSalaryDto>>(employeeDtos)).Returns(mappedDtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal(60000, result[0].Employee_Annual_Salary);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnMappedEmployee_WhenFound()
        {
            // Arrange
            var employeeDto = new EmployeeDto { Id = 1, Employee_Name = "Jose", Employee_Salary = 7000 };
            var mappedDto = new EmployeeWithAnnualSalaryDto { Id = 1, Employee_Name = "Jose", Employee_Annual_Salary= 84000 };

            _mockApiClient.Setup(x => x.GetEmployeeByIdAsync(1)).ReturnsAsync(employeeDto);
            _mockMapper.Setup(m => m.Map<EmployeeWithAnnualSalaryDto>(employeeDto)).Returns(mappedDto);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(84000, result.Employee_Annual_Salary);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowKeyNotFoundException_WhenEmployeeNotFound()
        {
            // Arrange
            _mockApiClient.Setup(x => x.GetEmployeeByIdAsync(99)).ReturnsAsync((EmployeeDto)null);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.GetByIdAsync(99));
            Assert.Equal("Employee with id 99 not found.", ex.Message);
        }
    }
}
