using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Model;

namespace WeatherApp.Utils
{
    class APIRequest
    {
        private readonly String API_KEY = "ce5cae10e6dca0a8a70d4fe71961ed8d";
        private readonly String COUNTRY_CODE = "PT";
        private readonly String KEY = "AIzaSyBdjaqoJwM6gsICogyRii43T4YcWrObdYM"; //google

        public async void GetJSONWeatherRequest(int requestType, string city)
        {
            // Check network status  
            if (await NetworkCheck.IsInternetAsync())
            {

                var client = new System.Net.Http.HttpClient();

                string URL = "https://api.openweathermap.org/data/2.5/";

                if (requestType == 0)
                {
                    URL += "weather?q=";
                } else if (requestType == 1)
                {
                    URL += "forecast?q=";
                }

                URL += city + "," + COUNTRY_CODE + "&units=metric&appid=" + API_KEY;

                var response = await client.GetAsync(URL);
                string weatherJsonResponse = await response.Content.ReadAsStringAsync();

                WeatherRootObject objWeatherInfo = new WeatherRootObject();
                if (weatherJsonResponse != "")
                {
                    objWeatherInfo = JsonConvert.DeserializeObject<WeatherRootObject>(weatherJsonResponse);
                }

                Console.WriteLine("City name:" + objWeatherInfo.cityName);

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
