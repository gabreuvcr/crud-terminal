using Laboratory.Models.Enums;

namespace Laboratory.Models.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Role { get; set; }
        public Gender Gender { get; set; }
    }
}
