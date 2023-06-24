using Microsoft.AspNetCore.Hosting.Server;
using System.Diagnostics.Metrics;

namespace NewShoreAir
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
// Server = localhost; Database = master; Trusted_Connection = True;