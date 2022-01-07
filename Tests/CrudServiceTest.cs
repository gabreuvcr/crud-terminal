using Laboratory.Models;
using Laboratory.Models.Enums;
using Xunit;

namespace Laboratory.Tests
{
    public class CrudTest
    {
        [Fact]
        public void AddEmployeeTest()
        {
            CrudService crud = new CrudService();
            Employee employee = new Employee("John", 3200, "Frontend", Gender.Masculine);
            
            crud.AddEmployee(employee);

            Employee addedEmployee = crud.FindEmployeeById(employee.Id);

            Assert.Equal(employee, addedEmployee);
        }
    }
}
