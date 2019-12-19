using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using System.Diagnostics;

namespace WeatherApp.Utils
{
    public static class Utils
    {
        public static string retrieveWeatherBackgroundIconDay(string main_description, string description)
        {
            switch(main_description)
            {
                case "Clear":
                    return "clear_sky.png";
                case "Clouds":
                    if (description.Equals("few clouds"))
                    {
                        return "few_clouds.png";
                    } else if (description.Equals("scattered clouds"))
                    {
                        return "scattered_clouds.png";
                    } else if (description.Equals("broken clouds"))
                    {
                        return "broken_clouds.png";
                    }
                    else
                    {
                        return "broken_clouds.png";
                    }
                case "Snow":
                    return "snow.png";
                case "Rain":
                    if (description.Equals("light rain") || description.Equals("moderate rain") || description.Equals("heavy intensity rain"))
                    {
                        Debug.Write("Ola");
                        return "rain.png";
                    }
                    else if (description.Equals("freezing rain"))
                    {
                        return "snow.png";
                    }
                    else
                    {
                        return "shower_rain.png";
                    }
                case "Drizzle":
                    return "shower_rain.png";
                case "Thunderstorm":
                    return "thunderstorm.png";
                case "Mist":
                    return "mist.png";
                default:
                    return "mist.png";

            }
        }

        public static string retrieveWeatherBackgroundIconNight(string main_description, string description)
        {
            switch (main_description)
            {
                case "Clear":
                    return "clear_sky_n.png";
                case "Clouds":
                    if (description.Equals("few clouds"))
                    {
                        return "few_clouds_n.png";
                    }
                    else if (description.Equals("scattered clouds"))
                    {
                        return "scattered_clouds_n.png";
                    }
                    else if (description.Equals("broken clouds"))
                    {
                        return "broken_clouds_n.png";
                    }
                    else
                    {
                        return "rain_n.png"; // return "broken_clouds_n.png";
                    }
                case "Snow":
                    return "snow_n.png";
                case "Rain":
                    if (description.Equals("light rain") || description.Equals("moderate rain") || description.Equals("heavy intensity rain"))
                    {
                        
                        return "rain_n.png";
                    }
                    else if (description.Equals("freezing rain"))
                    {
                        return "snow_n.png";
                    }
                    else
                    {
                        return "shower_rain_n.png";
                    }
                case "Drizzle":
                    return "shower_rain_n.png";
                case "Thunderstorm":
                    return "thunderstorm_n.png";
                case "Mist":
                    return "mist_n.png";
                default:
                    return "mist_n.png";

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
        public static string hourIcon()
        {
            DateTime localDate = DateTime.Now;
            Debug.WriteLine("hora: " + localDate.Hour.ToString());
                
            int value = Convert.ToInt32(localDate.Hour.ToString());

            if (value >= 0 && value <= 6)
            {
                return "night";
            } else if (value >= 7 && value <= 18)
            {
                return "day";
            } else
                return "night";
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
