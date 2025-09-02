using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.EMS.Models;
public class EmployeeEditVm {
        public int? Id { get; set; }

        [Required, StringLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Phone, StringLength(30)]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.UtcNow.Date;

        [Range(0, 1_000_000)]
        public decimal Salary { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int JobTitleId { get; set; }

        public string? ExistingImagePath { get; set; }
        public IFormFile? Image { get; set; }

        public SelectList? Departments { get; set; }
        public SelectList? JobTitles { get; set; }
    }

