using System;
using Newtonsoft.Json;

namespace Console.Models;
    public class WeatherResponse
    {
        [JsonProperty("name")]
        public string CityName { get; set; }
        
        [JsonProperty("main")]
        public MainData Main { get; set; }
        
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        
        [JsonProperty("sys")]
        public SystemData System { get; set; }
    }

    public class MainData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        
        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
        
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string Main { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        
        [JsonProperty("deg")]
        public int Direction { get; set; }
    }

    public class SystemData
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }
        
        [JsonProperty("sunset")]
        public long Sunset { get; set; }
    }

