
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.EMS.Models;

public class Department {
    [Key]
    public int Id { get; set; }
    // [AllowedValues("IT", "HR")]
    public string Name { get; set; }
    public List<Employee> employees { get; set; }
}