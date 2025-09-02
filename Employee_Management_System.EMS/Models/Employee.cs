
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.EMS.Models;

public class Employee {
    [Key]
    // [System.ComponentModel.DataAnnotations.]
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string? ProfileImagePath { get; set; }

    public int Department_id { get; set; }
    [ForeignKey(nameof(Department_id))]
    public Department department { get; set; }

    public int Job_id { get; set; }
    [ForeignKey(nameof(Job_id))]
    public Job job { get; set; }
}