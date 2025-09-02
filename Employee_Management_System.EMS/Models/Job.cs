
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.EMS.Models;

public class Job {
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public List<Employee>? employees { get; set; }

    public Department? department { get; set; }
    [ForeignKey(nameof(department))]
    public int DepartmentId { get; set; }
}