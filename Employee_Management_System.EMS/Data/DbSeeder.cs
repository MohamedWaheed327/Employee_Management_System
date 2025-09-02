using Employee_Management_System.EMS.Models;

namespace Employee_Management_System.EMS.Data {
    public static class DbSeeder {
        public static async Task SeedAsync(AppDbContext db) {
            if (!db.Departments.Any()) {
                db.Departments.AddRange(
                    new Department { Name = "HR" },
                    new Department { Name = "IT" },
                    new Department { Name = "Finance" });
            }
            if (!db.JobTitles.Any()) {
                db.JobTitles.AddRange(
                    new Job { Title = "Developer" },
                    new Job { Title = "Tester" },
                    new Job { Title = "Manager" });
            }
            await db.SaveChangesAsync();
        }
    }
}
