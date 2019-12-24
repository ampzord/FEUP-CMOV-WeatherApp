using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WeatherApp2.Model;
//using static WeatherApp.Model.RequestJSONForecast;

namespace WeatherApp2.Utils
{
    public partial class APIRequest
    {
        private static readonly String API_KEY = "ce5cae10e6dca0a8a70d4fe71961ed8d";
        private static readonly String COUNTRY_CODE = "PT";
        //private static readonly String KEY = "AIzaSyBdjaqoJwM6gsICogyRii43T4YcWrObdYM"; //google

        //Request https://api.openweathermap.org/data/2.5/weather?q=Porto,PT&units=metric&appid=ce5cae10e6dca0a8a70d4fe71961ed8d

        public static async Task<WeatherRootObject> GetJSONWeatherRequest(string city)
        {

            var client = new System.Net.Http.HttpClient();

            string URL = "https://api.openweathermap.org/data/2.5/";

            URL += "weather?q=" + city + "," + COUNTRY_CODE + "&units=metric&appid=" + API_KEY;

            //Debug.WriteLine("Weather URL: " + URL);

            try
            {
                System.Net.Http.HttpResponseMessage response = await client.GetAsync(URL);
                string weatherJsonResponse = await response.Content.ReadAsStringAsync();

                WeatherRootObject objWeatherInfo = new WeatherRootObject();
                if (weatherJsonResponse != "")
                {
                    objWeatherInfo = JsonConvert.DeserializeObject<WeatherRootObject>(weatherJsonResponse);
                }

                Debug.WriteLine("City Name (Weather): " + objWeatherInfo.name);
                return objWeatherInfo;
            }
            catch (ArgumentNullException e)
            {
                Debug.WriteLine("Error Argument Null Exception Weather Request: " + e);
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                Debug.WriteLine("Error System.Net.Http.HttpRequestException Weather Request: " + e);
            }

            return null;

            //Binding listview with server response    
            //listviewConacts.ItemsSource = ObjContactList.contacts;
        }

        public static async Task<ForecastRootObject> GetJSONForecastRequest(string city)
        {
            var client = new System.Net.Http.HttpClient();

            string URL = "https://api.openweathermap.org/data/2.5/";

            URL += "forecast?q=" + city + "," + COUNTRY_CODE + "&units=metric&appid=" + API_KEY;
            //Debug.WriteLine("Forecast Request URL: " + URL);

            try
            {
                System.Net.Http.HttpResponseMessage response = await client.GetAsync(URL);
                string weatherJsonResponse = await response.Content.ReadAsStringAsync();

                ForecastRootObject objWeatherInfo = new ForecastRootObject();
                if (weatherJsonResponse != "")
                {
                    objWeatherInfo = JsonConvert.DeserializeObject<ForecastRootObject>(weatherJsonResponse);
                }

                Debug.WriteLine("City Name (Forecast): " + objWeatherInfo.city.name);
                //Debug.WriteLine("Base: " + objWeatherInfo.Base);
                //Debug.WriteLine("Lat: " + objWeatherInfo.coord.lat);
                return objWeatherInfo;
            }
            catch (ArgumentNullException e)
            {
                Debug.WriteLine("Error Argument Null Exception Forecast Request: " + e);
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                Debug.WriteLine("Error System.Net.Http.HttpRequestException Forecast Request: " + e);
            }
            return null;
        }
    }
}
