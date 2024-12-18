using CMSAPIOnetoMany.Service;
using CMSAPIOnetoMany.Interface;
using CMSAPIOnetoMany.Models;
using CMSAPIOnetoMany.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmpCmpnyContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CMSConn")));
builder.Services.AddScoped<IEmployee, EmployeeRepository>();
builder.Services.AddScoped<ICompany, CompanyRepository>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
