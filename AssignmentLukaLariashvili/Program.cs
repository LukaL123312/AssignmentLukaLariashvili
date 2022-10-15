using AssignmentLukaLariashvili.Api.ApiHelpers;
using AssignmentLukaLariashvili.Bal.Services;
using AssignmentLukaLariashvili.Dal;
using AssignmentLukaLariashvili.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddDbContext<AssignmentDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AssignmentLukaLariashviliDbConnectionString")));
builder.Services.InitializeDatabase();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
