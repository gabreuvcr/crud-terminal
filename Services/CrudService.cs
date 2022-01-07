using System.Collections.Generic;
using Laboratory.Models;

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
            return employees[0];
        }
    }
}
