namespace Employees_App.Models.DTO
{
    public class EmployeeWithAnnualSalaryDto
    {
        public int Id { get; set; }
        public string Employee_Name { get; set; }
        public decimal Employee_Salary { get; set; }
        public decimal Employee_Annual_Salary { get; set; }
    }
}
