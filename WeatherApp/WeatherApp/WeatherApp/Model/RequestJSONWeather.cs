using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Model
{
    public class Coordinates
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class MainInformation
    {
        public double temperature { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int degrees { get; set; } //direction of the wind on degrees
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class System
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class WeatherRootObject
    {
        public Coordinates coord { get; set; }
        public List<Weather> weather { get; set; }
        public string base_info { get; set; } //"stations"
        public MainInformation main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public System sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string cityName { get; set; }
        public int cod { get; set; }
    }
}
