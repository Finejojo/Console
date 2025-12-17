using System;
using System.Net;
using Console.Models;
using Newtonsoft.Json;

namespace Console.Services;

 public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "6fe7c55df080e3c7825077181bad4f39"; 
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<WeatherResponse> GetWeatherAsync(string cityName)
        {
            try
            {
                // Construct the API URL with parameters
                var url = $"{BaseUrl}?q={cityName}&appid={ApiKey}&units=metric";
                
                // Make the HTTP GET request
                var response = await _httpClient.GetAsync(url);
                
                // Check if request was successful
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception($"City '{cityName}' not found. Please check the spelling.");
                }
                
                response.EnsureSuccessStatusCode();
                
                // Read and parse the JSON response
                var json = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(json);
                
                return weatherData;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Network error: {ex.Message}");
            }
            catch (TaskCanceledException)
            {
                throw new Exception("Request timed out. Please try again.");
            }
            catch (JsonException)
            {
                throw new Exception("Error parsing weather data. Please try again.");
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
