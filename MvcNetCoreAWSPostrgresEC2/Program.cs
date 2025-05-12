using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostrgresEC2.Data;
using MvcNetCoreAWSPostrgresEC2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//string connectionString =
//    builder.Configuration.GetConnectionString("Postgres");
//builder.Services.AddTransient<RepositoryHospital>();
//builder.Services.AddDbContext<HospitalContext>
//    (options => options.UseNpgsql(connectionString));

builder.Services.AddTransient
    <RepositoryHospital>();
string connectionString =
    builder.Configuration.GetConnectionString("Mariadb");
builder.Services.AddDbContext<HospitalContext>
    (options => options.UseMySQL(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
