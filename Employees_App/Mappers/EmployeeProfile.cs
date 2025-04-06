using AutoMapper;
using Employees_App.Models.DTO;

namespace Employees_App.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, EmployeeWithAnnualSalaryDto>()
                    .ForMember(dest => dest.Employee_Annual_Salary,
                     opt => opt.MapFrom(src => src.Employee_Salary * Constants.ProjectConstants.SalaryConstants.ValueCalculateAnnualSalary));
        }
    }
}
