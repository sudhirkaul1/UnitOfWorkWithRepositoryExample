using Microsoft.EntityFrameworkCore;
using UnitOfWorkWithRepository.Data;
using UnitOfWorkWithRepository.EntityRepositories;
using UnitOfWorkWithRepository.Models;
using UnitOfWorkWithRepository.Repositories;
using UnitOfWorkWithRepository.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(connectionString);
});

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped(typeof(IUnitofwork<>), typeof(UnitOfWork<>));

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
