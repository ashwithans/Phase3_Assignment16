using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAppCoreMVC.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<School2023DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolConStr")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
