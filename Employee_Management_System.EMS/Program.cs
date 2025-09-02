
using Employee_Management_System.EMS.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EMS_DBcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ITIConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   app.UseExceptionHandler("/Home/Error");
   // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   app.UseHsts();
}

app.UseHttpsRedirection();//Mohammed Ramadan
app.UseRouting();//Waheed

app.UseAuthorization(); // Abo Adel 

app.MapStaticAssets(); // Thaer

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

/*
    dotnet ef migrations add InitialCreate
    dotnet ef database update
*/
