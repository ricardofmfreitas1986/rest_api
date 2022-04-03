using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MedicationRESTApi.Context;
using MedicationRESTApi.Contracts;
using MedicationRESTApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("cs");
builder.Services.AddDbContext<PharmacyDBContext>( options =>
options.UseSqlite(connectionString ) );

builder.Services.AddScoped<IMedicationService, MedicationService>();
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
