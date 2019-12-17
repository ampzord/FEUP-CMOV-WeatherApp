using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WeatherApp.Model;

namespace WeatherApp.Utils
{
    public partial class APIRequest
    {
        private static readonly String API_KEY = "ce5cae10e6dca0a8a70d4fe71961ed8d";
        private static readonly String COUNTRY_CODE = "PT";
        private static readonly String KEY = "AIzaSyBdjaqoJwM6gsICogyRii43T4YcWrObdYM"; //google

        //Request https://api.openweathermap.org/data/2.5/weather?q=Porto,PT&units=metric&appid=ce5cae10e6dca0a8a70d4fe71961ed8d

        public static async void GetJSONWeatherRequest(int requestType, string city)
        {
            // Check network status  
            if (NetworkCheck.IsInternetAsync())
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

                    Debug.WriteLine("City name: " + objWeatherInfo.name);
                    Debug.WriteLine("Base: " + objWeatherInfo.Base);
                    Debug.WriteLine("Lat: " + objWeatherInfo.coord.lat);
                } catch (ArgumentNullException e)
                {
                    Debug.WriteLine("Error Argument Null Exception Weather Request: " + e);
                } catch (System.Net.Http.HttpRequestException e)
                {
                    Debug.WriteLine("Error System.Net.Http.HttpRequestException Weather Request: " + e);
                }

                //Binding listview with server response    
                //listviewConacts.ItemsSource = ObjContactList.contacts;
            }
            else
            {
                //await DisplayAlert("JSONParsing", "No network is available.", "Ok");
            }

            //Hide loader after server response    
            //ProgressLoader.IsVisible = false;
        }

        public static async void GetJSONForecastRequest(string city)
        {
            // Check network status  
            if (NetworkCheck.IsInternetAsync())
            {

                var client = new System.Net.Http.HttpClient();

                string URL = "https://api.openweathermap.org/data/2.5/";

                URL += "forecast?q=" + city + "," + COUNTRY_CODE + "&units=metric&appid=" + API_KEY;
                //Debug.WriteLine("Forecast Request URL: " + URL);

                try
                {
                    System.Net.Http.HttpResponseMessage response = await client.GetAsync(URL);
                    string weatherJsonResponse = await response.Content.ReadAsStringAsync();

                    WeatherRootObject objWeatherInfo = new WeatherRootObject();
                    if (weatherJsonResponse != "")
                    {
                        objWeatherInfo = JsonConvert.DeserializeObject<WeatherRootObject>(weatherJsonResponse);
                    }

                    Debug.WriteLine("City name: " + objWeatherInfo.name);
                    Debug.WriteLine("Base: " + objWeatherInfo.Base);
                    Debug.WriteLine("Lat: " + objWeatherInfo.coord.lat);
                }
                catch (ArgumentNullException e)
                {
                    Debug.WriteLine("Error Argument Null Exception Forecast Request: " + e);
                }
                catch (System.Net.Http.HttpRequestException e)
                {
                    Debug.WriteLine("Error System.Net.Http.HttpRequestException Forecast Request: " + e);
                }

                //Binding listview with server response    
                //listviewConacts.ItemsSource = ObjContactList.contacts;
            }
            else
            {
                //await DisplayAlert("JSONParsing", "No network is available.", "Ok");
            }

            //Hide loader after server response    
            //ProgressLoader.IsVisible = false;
        }
    }
}
