using Employee_Management_System.EMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee_Management_System.EMS.Models;

public class EmployeeListVm {
        public string? Search { get; set; }
        public int? DepartmentId { get; set; }
        public int? JobTitleId { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }

        public List<Employee> Items { get; set; } = new();

        public SelectList? Departments { get; set; }
        public SelectList? JobTitles { get; set; }
    }


