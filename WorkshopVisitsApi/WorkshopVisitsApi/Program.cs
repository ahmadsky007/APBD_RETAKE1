using Microsoft.EntityFrameworkCore;
using WorkshopVisitsApi.Data;
using WorkshopVisitsApi.Repositories.Interfaces;
using WorkshopVisitsApi.Repositories.Implementations;
using WorkshopVisitsApi.Services.Interfaces;
using WorkshopVisitsApi.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register EF Core DbContext
builder.Services.AddDbContext<WorkshopVisitsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection for Repository and Service
builder.Services.AddScoped<IVisitsRepository, VisitsRepository>();
builder.Services.AddScoped<IVisitsService, VisitsService>();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();