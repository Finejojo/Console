using System;
using Console.Models;
using System.Linq;

namespace Console.Services;

public class DisplayService
    {
        public void ShowWeather(WeatherResponse weather)
        {
             System.Console.Clear();
             System.Console.WriteLine("=== WEATHER DASHBOARD ===");
             System.Console.WriteLine($"📍 {weather.CityName}, {weather.System.Country}");
             System.Console.WriteLine("──────────────────────────");
            
            if (weather.Weather != null && weather.Weather.Any())
            {
                var weatherInfo = weather.Weather[0];
                 System.Console.WriteLine($"Weather: {weatherInfo.Main} ({weatherInfo.Description})");
            }
            
             System.Console.WriteLine($"Temperature: {weather.Main.Temperature}°C");
             System.Console.WriteLine($"Feels like: {weather.Main.FeelsLike}°C");
             System.Console.WriteLine($"Humidity: {weather.Main.Humidity}%");
             System.Console.WriteLine($"Pressure: {weather.Main.Pressure} hPa");
             System.Console.WriteLine($"Wind: {weather.Wind.Speed} m/s, {GetWindDirection(weather.Wind.Direction)}");
            
            var sunrise = DateTimeOffset.FromUnixTimeSeconds(weather.System.Sunrise).ToLocalTime();
            var sunset = DateTimeOffset.FromUnixTimeSeconds(weather.System.Sunset).ToLocalTime();
             System.Console.WriteLine($"Sunrise: {sunrise:HH:mm}");
             System.Console.WriteLine($"Sunset: {sunset:HH:mm}");
             System.Console.WriteLine("──────────────────────────");
        }

        public void ShowError(string errorMessage)
        {
             System.Console.ForegroundColor = ConsoleColor.Red;
             System.Console.WriteLine($"❌ Error: {errorMessage}");
             System.Console.ResetColor();
        }

        public void ShowWelcome()
        {
             System.Console.ForegroundColor = ConsoleColor.Cyan;
             System.Console.WriteLine("🌤️  Welcome to Weather Dashboard!");
             System.Console.ResetColor();
             System.Console.WriteLine("Enter a city name to get current weather information.");
             System.Console.WriteLine("Type 'quit' to exit the application.");
             System.Console.WriteLine();
        }

        private string GetWindDirection(int degrees)
        {
            return degrees switch
            {
                >= 0 and < 45 => "N",
                >= 45 and < 90 => "NE",
                >= 90 and < 135 => "E",
                >= 135 and < 180 => "SE",
                >= 180 and < 225 => "S",
                >= 225 and < 270 => "SW",
                >= 270 and < 315 => "W",
                _ => "NW"
            };
        }
    }
