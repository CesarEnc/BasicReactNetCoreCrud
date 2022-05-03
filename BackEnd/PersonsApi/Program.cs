using Microsoft.EntityFrameworkCore;
using PersonsApi.Implementations.Services;
using PersonsApi.Interfaces.Services;
using PersonsApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injecting Dependecies 
builder.Services.AddTransient<IPersonsService, PersonsService>();
builder.Services.AddDbContext<PersonsDBContext>(options => options.UseSqlServer("name=PersonsDB"));

//Configuring CORS
builder.Services.AddCors(p => p.AddPolicy("BasicCORS", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("BasicCORS");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
