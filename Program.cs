using Console.Services;
using System.Linq;
using System;

namespace WeatherDashboard
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var weatherService = new WeatherService();
            var displayService = new DisplayService();

            displayService.ShowWelcome();

            while (true)
            {
                try
                {
                      System.Console.Write("Enter city name: ");
                    var cityName =  System.Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(cityName))
                    {
                        continue;
                    }

                    if (cityName.Equals("quit", StringComparison.OrdinalIgnoreCase))
                    {
                         System.Console.WriteLine("Thank you for using Weather Dashboard! 👋");
                        break;
                    }

                     System.Console.WriteLine("⏳ Fetching weather data...");

                    // Call the API
                    var weather = await weatherService.GetWeatherAsync(cityName);
                    
                    // Display the results
                    displayService.ShowWeather(weather);
                }
                catch (Exception ex)
                {
                    displayService.ShowError(ex.Message);
                }

                 System.Console.WriteLine();
                 System.Console.WriteLine("Press any key to check another city...");
                 System.Console.ReadKey();
                 System.Console.WriteLine();
            }

            weatherService.Dispose();
        }
    }
}