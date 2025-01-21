using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class WeatherForecastFunction
    {
        private readonly ILogger _logger;

        public WeatherForecastFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<WeatherForecastFunction>();
        }

        [Function("WeatherForecast")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequestData req)
        {

            List<string> Forecasts = new List<String>
            {
                "Hot", "Cold", "Weather 1", "Weather 2", "Lorem", "Ipsum", "Dolor"
            };


            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(Forecasts);
            return response;
        }
    }
}
