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

        [Fact]
        public void FindAllEmployeesTest()
        {
            CrudService crud = new CrudService();
            Employee employee1 = new Employee("Anne", 3200, "Backend", Gender.Feminine);
            Employee employee2 = new Employee("John", 3200, "Frontend", Gender.Masculine);

            crud.AddEmployee(employee1);
            crud.AddEmployee(employee2);

            List<Employee> employees = crud.FindAllEmployees();

            Assert.Equal(employee1, employees[0]);
            Assert.Equal(employee2, employees[1]);
        }

        [Fact]
        public void FindAllEmployeesWhenListIsEmptyTest()
        {
            CrudService crud = new CrudService();

            List<Employee> employees = crud.FindAllEmployees();

            Assert.Empty(employees);
        }

        [Fact]
        public void UpdateEmployeeByIdTest()
        {
            CrudService crud = new CrudService();
            Employee employee = new Employee("John", 3200, "Frontend", Gender.Masculine);

            crud.AddEmployee(employee);

            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.Id = employee.Id;
            employeeDTO.Name = "Joao";
            employeeDTO.Salary = 4500;
            employeeDTO.Role = "Frontend";
            employeeDTO.Gender = Gender.Masculine;

            crud.UpdateEmployeeById(employeeDTO);
            employee = crud.FindEmployeeById(employeeDTO.Id);
    
            Assert.Equal("Joao", employee.Name);
            Assert.Equal(4500, employee.Salary);
            Assert.Equal(employeeDTO.Id, employee.Id);
        }

        [Fact]
        public void RemoveEmployeeTest()
        {
            CrudService crud = new CrudService();
            Employee employee1 = new Employee("John", 3200, "Frontend", Gender.Masculine);
            Employee employee2 = new Employee("Anne", 3200, "Backend", Gender.Feminine);
            
            crud.AddEmployee(employee1);
            crud.AddEmployee(employee2);

            Employee removedEmployee = crud.RemoveEmployeeById(employee2.Id);

            Assert.Equal(employee2, removedEmployee);
        }

        [Fact]
        public void RemovedEmployeeAndCheckListLengthTest()
        {
            CrudService crud = new CrudService();
            Employee employee1 = new Employee("John", 3200, "Frontend", Gender.Masculine);
            Employee employee2 = new Employee("Anne", 3200, "Backend", Gender.Feminine);
            
            crud.AddEmployee(employee1);
            crud.AddEmployee(employee2);

            crud.RemoveEmployeeById(employee1.Id);

            List<Employee> employees = crud.FindAllEmployees();

            Assert.Single(employees);
        }
    }
}
