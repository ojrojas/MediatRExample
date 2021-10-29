using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatRExample.Repository
{
    public class WeatherForecastRepository
    {
        private static readonly string[] Summaries = new[] {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};
        public List<WeatherForecast> ListWeatherForeCast { get; } = Enumerable.Range(1, 10).Select(index => new WeatherForecast
        {
            Id =index, 
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
    }
}