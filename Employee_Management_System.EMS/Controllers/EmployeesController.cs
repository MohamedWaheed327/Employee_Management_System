using Employee_Management_System.EMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class EmployeesController : Controller {
   private readonly AppDbContext _db;
   private readonly IWebHostEnvironment _env;

   public EmployeesController(AppDbContext db, IWebHostEnvironment env) {
      _db = db;
      _env = env;
   }

   public async Task<IActionResult> Index(string? search, int? departmentId, int? jobTitleId, int page = 1, int pageSize = 10) {
      var query = _db.Employees
          .Include(e => e.department)
          .Include(e => e.job)
          .AsQueryable();

      if (!string.IsNullOrWhiteSpace(search)) {
         search = search.Trim();
         query = query.Where(e => e.FullName.Contains(search) || e.Email.Contains(search));
      }
      if (departmentId.HasValue) {
         query = query.Where(e => e.Department_id == departmentId.Value);
      }
      if (jobTitleId.HasValue) {
         query = query.Where(e => e.Job_id == jobTitleId.Value);
      }

      var total = await query.CountAsync();
      var items = await query
          .OrderBy(e => e.FullName)
          .Skip((page - 1) * pageSize)
          .Take(pageSize)
          .ToListAsync();

      var vm = new EmployeeListVm {
         Search = search,
         DepartmentId = departmentId,
         JobTitleId = jobTitleId,
         Page = page,
         PageSize = pageSize,
         TotalCount = total,
         Items = items,
         Departments = new SelectList(await _db.Departments.OrderBy(d => d.Name).ToListAsync(), "Id", "Name"),
         JobTitles = new SelectList(await _db.JobTitles.OrderBy(j => j.Title).ToListAsync(), "Id", "Title")
      };
      return View(vm);
   }

   public async Task<IActionResult> Details(int id) {
      var e = await _db.Employees
          .Include(x => x.department)
          .Include(x => x.job)
          .FirstOrDefaultAsync(x => x.Id == id);
      if (e == null) return NotFound();
      return View(e);
   }

   public async Task<IActionResult> Create() {
      var vm = new EmployeeEditVm {
         Departments = new SelectList(await _db.Departments.OrderBy(d => d.Name).ToListAsync(), "Id", "Name"),
         JobTitles = new SelectList(await _db.JobTitles.OrderBy(j => j.Title).ToListAsync(), "Id", "Title")
      };
      return View(vm);
   }

   [HttpPost]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> Create(EmployeeEditVm vm) {
      if (!ModelState.IsValid) {
         vm.Departments = new SelectList(await _db.Departments.ToListAsync(), "Id", "Name", vm.DepartmentId);
         vm.JobTitles = new SelectList(await _db.JobTitles.ToListAsync(), "Id", "Title", vm.JobTitleId);
         return View(vm);
      }

      // Unique Email Validation
      if (await _db.Employees.AnyAsync(e => e.Email == vm.Email)) {
         ModelState.AddModelError("Email", "This email is already in use");
         vm.Departments = new SelectList(await _db.Departments.ToListAsync(), "Id", "Name", vm.DepartmentId);
         vm.JobTitles = new SelectList(await _db.JobTitles.ToListAsync(), "Id", "Title", vm.JobTitleId);
         return View(vm);
      }

      var emp = new Employee {
         FullName = vm.FullName,
         Email = vm.Email,
         PhoneNumber = vm.PhoneNumber,
         HireDate = vm.HireDate,
         Salary = vm.Salary,
         Department_id = vm.DepartmentId,
         Job_id = vm.JobTitleId,
         ProfileImagePath = await SaveImageAsync(vm.Image)
      };

      _db.Employees.Add(emp);
      await _db.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
   }

   public async Task<IActionResult> Edit(int id) {
      var e = await _db.Employees.FindAsync(id);
      if (e == null) return NotFound();

      var vm = new EmployeeEditVm {
         Id = e.Id,
         FullName = e.FullName,
         Email = e.Email,
         PhoneNumber = e.PhoneNumber,
         HireDate = e.HireDate,
         Salary = e.Salary,
         DepartmentId = e.Department_id,
         JobTitleId = e.Job_id,
         ExistingImagePath = e.ProfileImagePath,
         Departments = new SelectList(await _db.Departments.OrderBy(d => d.Name).ToListAsync(), "Id", "Name", e.Department_id),
         JobTitles = new SelectList(await _db.JobTitles.OrderBy(j => j.Title).ToListAsync(), "Id", "Title", e.Job_id)
      };
      return View(vm);
   }

   [HttpPost]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> Edit(int id, EmployeeEditVm vm, string? command) {
      if (id != vm.Id) return BadRequest();

      if (!ModelState.IsValid) {
         vm.Departments = new SelectList(await _db.Departments.ToListAsync(), "Id", "Name", vm.DepartmentId);
         vm.JobTitles = new SelectList(await _db.JobTitles.ToListAsync(), "Id", "Title", vm.JobTitleId);
         return View(vm);
      }

      var e = await _db.Employees.FindAsync(id);
      if (e == null) return NotFound();

      e.FullName = vm.FullName;
      e.Email = vm.Email;
      e.PhoneNumber = vm.PhoneNumber;
      e.HireDate = vm.HireDate;
      e.Salary = vm.Salary;
      e.Department_id = vm.DepartmentId;
      e.Job_id = vm.JobTitleId;

      if (vm.Image != null) {
         if (!string.IsNullOrEmpty(e.ProfileImagePath))
            DeleteImage(e.ProfileImagePath);

         e.ProfileImagePath = await SaveImageAsync(vm.Image);
      }

      await _db.SaveChangesAsync();

      if (string.Equals(command, "apply", StringComparison.OrdinalIgnoreCase))
         return RedirectToAction(nameof(Edit), new { id });

      return RedirectToAction(nameof(Index));
   }

   public async Task<IActionResult> Delete(int id) {
      var e = await _db.Employees
          .Include(x => x.department)
          .Include(x => x.job)
          .FirstOrDefaultAsync(x => x.Id == id);
      if (e == null) return NotFound();
      return View(e);
   }

   [HttpPost, ActionName("Delete")]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> DeleteConfirmed(int id) {
      var e = await _db.Employees.FindAsync(id);
      if (e != null) {
         if (!string.IsNullOrEmpty(e.ProfileImagePath))
            DeleteImage(e.ProfileImagePath);

         _db.Employees.Remove(e);
         await _db.SaveChangesAsync();
      }
      return RedirectToAction(nameof(Index));
   }

   private async Task<string?> SaveImageAsync(IFormFile? image) {
      if (image == null || image.Length == 0) return null;

      var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
      var ext = Path.GetExtension(image.FileName).ToLowerInvariant();
      if (!allowed.Contains(ext)) throw new InvalidOperationException("Invalid image type.");
      if (image.Length > 2 * 1024 * 1024) throw new InvalidOperationException("Max 2MB.");

      var fileName = $"{Guid.NewGuid():N}{ext}";
      var relPath = Path.Combine("images", "employees", fileName);
      var absDir = Path.Combine(_env.WebRootPath, "images", "employees");
      Directory.CreateDirectory(absDir);
      var absPath = Path.Combine(absDir, fileName);

      using (var stream = System.IO.File.Create(absPath))
         await image.CopyToAsync(stream);

      return "/" + relPath.Replace("\\", "/");
   }

   private void DeleteImage(string relativePath) {
      var path = relativePath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString());
      var abs = Path.Combine(_env.WebRootPath, path);
      if (System.IO.File.Exists(abs))
         System.IO.File.Delete(abs);
   }
}
