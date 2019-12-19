using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace WeatherApp.Utils
{
    public static class Utils
    {
        public static string retrieveWeatherBackgroundIconDay(string main_description, string description)
        {
            switch(main_description)
            {
                case "Clear":
                    return "clear_sky.jpg";
                case "Clouds":
                    if (description.Equals("few clouds"))
                    {
                        return "few_clouds.jpg";
                    } else if (description.Equals("scattered clouds"))
                    {
                        return "scattered_clouds.jpg";
                    } else if (description.Equals("broken clouds"))
                    {
                        return "broken_clouds.jpg";
                    }
                    else
                    {
                        return "broken_clouds.jpg";
                    }
                case "Snow":
                    return "snow.jpg";
                case "Rain":
                    if (description.Equals("light rain") || description.Equals("moderate rain") || description.Equals("heavy intensity rain"))
                    {
                        return "rain.jpg";
                    }
                    else if (description.Equals("freezing rain"))
                    {
                        return "snow.jpg";
                    }
                    else
                    {
                        return "shower_rain.jpg";
                    }
                case "Drizzle":
                    return "shower_rain.jpg";
                case "Thunderstorm":
                    return "thunderstorm.jpg";
                case "Mist":
                    return "mist.jpg";
                default:
                    return "mist.jpg";

            }
        }

        public static string retrieveWeatherBackgroundIconNight(string main_description, string description)
        {
            switch (main_description)
            {
                case "Clear":
                    return "clear_sky_n.jpg";
                case "Clouds":
                    if (description.Equals("few clouds"))
                    {
                        return "few_clouds_n.jpg";
                    }
                    else if (description.Equals("scattered clouds"))
                    {
                        return "scattered_clouds_n.jpg";
                    }
                    else if (description.Equals("broken clouds"))
                    {
                        return "broken_clouds_n.jpg";
                    }
                    else
                    {
                        return "broken_clouds_n.jpg";
                    }
                case "Snow":
                    return "snow_n.jpg";
                case "Rain":
                    if (description.Equals("light rain") || description.Equals("moderate rain") || description.Equals("heavy intensity rain"))
                    {
                        return "rain_n.jpg";
                    }
                    else if (description.Equals("freezing rain"))
                    {
                        return "snow_n.jpg";
                    }
                    else
                    {
                        return "shower_rain_n.jpg";
                    }
                case "Drizzle":
                    return "shower_rain_n.jpg";
                case "Thunderstorm":
                    return "thunderstorm_n.jpg";
                case "Mist":
                    return "mist_n.jpg";
                default:
                    return "mist_n.jpg";

            }
        }

        public static string getFavoriteCities()
        {
            return Preferences.Get("FavCities", "");
        }

        public static void setFavoriteCities(string value)
        {
            string prevValue = Preferences.Get("FavCities", "");

            if (prevValue == "")
            {
                Preferences.Set("FavCities", value);
            } else
            {
                string all_fav_cities = prevValue + "," + value;
                Preferences.Set("FavCities", all_fav_cities);
            }
            
        }

        //toRemove() - Preferences.Remove("my_key");
        //toRemoveAll() - Preferences.Clear();

        //working
        public static string hourIcon(string hour)
        {
            string[] words = hour.Split(' ');
            string temp_hour = words[1];

            string[] lines = Regex.Split(temp_hour, ":");

            switch (lines[0])
            {
                case "00":
                    return "night";
                case "03":
                    return "night";
                case "06":
                    return "night";
                case "09":
                    return "day";
                case "12":
                    return "day";
                case "15":
                    return "day";
                case "18":
                    return "day";
                case "21":
                    return "night";
                default:
                    return "day";
            }
        }

        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }
}
