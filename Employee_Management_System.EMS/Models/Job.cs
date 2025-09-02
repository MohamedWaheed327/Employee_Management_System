
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.EMS.Models;

public class Job {
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Employee> employees { get; set; }
}