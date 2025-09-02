using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.EMS.Models
{
    public class EmployeeEditVm
    {
        public int? Id { get; set; }

        [Required, StringLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required, StringLength(200)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.com$", ErrorMessage = "Email must contain @ and end with .com")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^01\d{9}$", ErrorMessage = "Phone number must start with 01 and be 11 digits")]
        public string? PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [HireDateRangeValidation(ErrorMessage = "Hire date must be between 2000-01-01 and 2030-12-31")]
        public DateTime HireDate { get; set; } = DateTime.UtcNow.Date;

        [Required]
        [Range(5000, 50000, ErrorMessage = "Salary must be between 5000 and 50000")]
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

    public class HireDateRangeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime hireDate)
            {
                if (hireDate >= new DateTime(2000, 1, 1) && hireDate <= new DateTime(2030, 12, 31))
                {
                    return ValidationResult.Success!;
                }
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
