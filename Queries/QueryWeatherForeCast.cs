using MediatR;
using MediatRExample.Repository;

namespace MediatRExample.Queries;

public class QueryWeatherForeCast
{
    public record WeatherForeCastRequest(int Id) : IRequest<WeatherForeCastResponse> { };
    public record WeatherForeCastResponse(int Id, DateTime Date, int TemperatureC, int TemperatureF, string? Summary);

    public class WeatherForeCastHandler : IRequestHandler<WeatherForeCastRequest, WeatherForeCastResponse>
    {
        private readonly WeatherForecastRepository _weatherForecastRepository;

        public WeatherForeCastHandler(WeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<WeatherForeCastResponse> Handle(WeatherForeCastRequest request, CancellationToken cancellationToken)
        {
            var weather = _weatherForecastRepository.ListWeatherForeCast.FirstOrDefault(i => i.Id == request.Id);
            await Task.CompletedTask;
            return weather == default ? default : new WeatherForeCastResponse(weather.Id,
                weather.Date,
                weather.TemperatureC,
                weather.TemperatureF,
                weather.Summary);
        }
    }
}
