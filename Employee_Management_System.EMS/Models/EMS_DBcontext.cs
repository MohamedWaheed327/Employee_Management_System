
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.EMS.Models;

public class EMS_DBcontext : DbContext {
    DbSet<Employee> employees;
    DbSet<Job> jobs;
    DbSet<Department> departments;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(@"Server=MOHAMMED-WAHEED; Database=ITI_EMS; Trusted_Connection=True;Integrated Security=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Employee>()
        .HasOne(e => e.department)
        .WithMany(d => d.employees)
        .HasForeignKey(e => e.Department_id);

        modelBuilder.Entity<Employee>()
        .HasOne(e => e.job)
        .WithMany(d => d.employees)
        .HasForeignKey(e => e.Job_id);
    }
}