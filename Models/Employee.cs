using System;
using Laboratory.Models.DTOs;
using Laboratory.Models.Enums;

namespace Laboratory.Models
{
    public class Employee
    {
        private static int IdCounter = 0;

        public int Id { get; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Role { get; set; }
        public Gender Gender { get; set; }


        public Employee(string name, double salary, string role, Gender gender)
        {
            Id = ++IdCounter;
            Name = name;
            Salary = salary;
            Role = role;
            Gender = gender;
        }

        public Employee(EmployeeDTO employeeDTO)
        {
            Id = ++IdCounter;
            Name = employeeDTO.Name;
            Salary = employeeDTO.Salary;
            Role = employeeDTO.Role;
            Gender = employeeDTO.Gender;
        }

        public override string ToString()
        {
            return $"{Name}, R${Salary}, {Role}, {Gender}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj is not Employee) return false;

            Employee other = obj as Employee;

            return this.Id == other.Id && this.Name.Equals(other.Name) &&
                this.Salary == other.Salary && this.Role == other.Role &&
                this.Gender == other.Gender;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Salary, Role, Gender);
        }
    }
}
