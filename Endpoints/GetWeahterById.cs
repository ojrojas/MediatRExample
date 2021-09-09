using Ardalis.ApiEndpoints;
using MediatR;
using MediatRExample.Queries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static MediatRExample.Queries.QueryWeatherForeCast;

namespace MediatRExample.Controllers;

public class GetWeahterById : BaseAsyncEndpoint.WithRequest<int>.WithResponse<WeatherForeCastResponse>
{
    private readonly IMediator _mediator;

    private readonly ILogger<GetWeahterById> _logger;

    public GetWeahterById(IMediator mediator, ILogger<GetWeahterById> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("api/getweatherbyid")]
    [ProducesResponseType(typeof(WeatherForeCastResponse), StatusCodes.Status200OK)]
    [SwaggerOperation(
           Summary = "get weather by id",
           Description = "get weather",
           OperationId = "weather.getweatherbyid",
           Tags = new[] { "WeatherForeCastEndpoint" })]
    public override async Task<ActionResult<WeatherForeCastResponse>> HandleAsync(int request, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new QueryWeatherForeCast.WeatherForeCastRequest(request));
    }
}
