using System.Collections.Generic;
using Laboratory.Models;
using Laboratory.Models.DTOs;
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

        [Fact]
        public void FindEmployeeByIdTest()
        {
            CrudService crud = new CrudService();
            Employee employee1 = new Employee("Anne", 3200, "Backend", Gender.Feminine);
            Employee employee2 = new Employee("John", 3200, "Frontend", Gender.Masculine);
            
            crud.AddEmployee(employee1);
            crud.AddEmployee(employee2);

            Employee employeeFindById1 = crud.FindEmployeeById(employee1.Id);
            Employee employeeFindById2 = crud.FindEmployeeById(employee2.Id);

            Assert.Equal(employee1, employeeFindById1);
            Assert.Equal(employee2, employeeFindById2);
        }
        
        [Fact]
        public void FindEmployeeByIdThatDoesNotExistTest()
        {
            CrudService crud = new CrudService();
            Employee employee = new Employee("John", 3200, "Frontend", Gender.Masculine);

            crud.AddEmployee(employee);

            Employee employeeFindById = crud.FindEmployeeById(-1);

            Assert.Null(employeeFindById);
        }
    }
}
