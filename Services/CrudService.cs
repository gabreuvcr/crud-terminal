using System.Collections.Generic;
using Laboratory.Models;
using Laboratory.Models.DTOs;

namespace Laboratory
{
    public class CrudService
    {        
        private List<Employee> employees = new List<Employee>();
        
        public CrudService() { }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee FindEmployeeById(int id)
        {
            foreach (Employee employee in employees) {
                if (employee.Id == id) return employee;
            }
            return null;
        }

        public List<Employee> FindAllEmployees()
        {
            return employees;
        }

        public void UpdateEmployeeById(EmployeeDTO employeeDTO)
        {
            Employee employee = FindEmployeeById(employeeDTO.Id);
            if (employee == null) return;

            int i = employees.IndexOf(employee);

            employees[i].Name = employeeDTO.Name;
            employees[i].Salary = employeeDTO.Salary;
            employees[i].Role = employeeDTO.Role;
            employees[i].Gender = employeeDTO.Gender;
        }
    }
}
