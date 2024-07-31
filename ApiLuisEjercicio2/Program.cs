using Application.Services;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra la interfaz IPersonaRepository con su implementación PersonaRepository
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>(sp => new PersonaRepository(
    builder.Configuration.GetConnectionString("Default")));

//var conect = builder.Configuration.GetConnectionString("Default");

// Registra el servicio IPersonaService con su implementación PersonaService
builder.Services.AddScoped<IPersonaService, PersonaService>();

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
