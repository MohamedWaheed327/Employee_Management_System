
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.EMS.Models;

public class Employee {
    [Key]
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string? ProfileImagePath { get; set; }
    public Department department { get; set; }
    public Job job { get; set; }
}