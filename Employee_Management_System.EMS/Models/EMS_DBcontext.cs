
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.EMS.Models;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Job> JobTitles => Set<Job>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.department)
            .WithMany(d => d.employees)
            .HasForeignKey(e => e.Department_id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.job)
            .WithMany(j => j.employees)
            .HasForeignKey(e => e.Job_id)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Job>()
            .HasOne(j => j.department)
            .WithMany(d => d.jobs)
            .HasForeignKey(j => j.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
