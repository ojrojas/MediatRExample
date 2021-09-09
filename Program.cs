using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;
using static MediatRExample.Queries.QueryWeatherForeCast;
using System.Security.Policy;
using MediatRExample.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AppDomain currentDomain = AppDomain.CurrentDomain;
Assembly[] assems = currentDomain.GetAssemblies();

//List the assemblies in the current application domain.
Console.WriteLine("List of assemblies loaded in current appdomain:");
foreach (Assembly assem in assems)
    Console.WriteLine(assem.GetName());

var assembly = assems.FirstOrDefault(x => x.FullName.Contains("MediatRExample"));

builder.Services.AddControllers();
builder.Services.AddSingleton<WeatherForecastRepository>();
builder.Services.AddMediatR(assembly);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MediatRExample", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediatRExample v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
