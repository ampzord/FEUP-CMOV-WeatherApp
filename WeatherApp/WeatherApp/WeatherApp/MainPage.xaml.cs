using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using WeatherApp.Utils;
using Xamarin.Forms;
using WeatherApp.Model;


namespace WeatherApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        private List<string> city_districts_pt =
                new List<string>() {
                "Leiria", "Porto", "Viana do Castelo", "Braga", "Vila Real", "Bragança", "Aveiro", "Viseu", "Guarda",
                "Coimbra", "Castelo Branco", "Santarém", "Castelo Branco", "Lisboa", "Portalegre",
                "Évora", "Setúbal", "Beja", "Faro"
        };

        //private List<string> favorite_cities;

        private WeatherRootObject weather_object;
        private ForecastRootObject forecast_object;

        public MainPage()
        {
            InitializeComponent();
            InititializeProgram();
        }

        private async void InititializeProgram()
        {
            DevicePlatform();
            Title = city_districts_pt[0] + ", Portugal";
            addCity.ItemsSource = city_districts_pt;
            addCity.SelectedItem = city_districts_pt[0];
            BindingContext = this;
            if (NetworkCheck.IsInternetAsync())
            {
                weather_object = await APIRequest.GetJSONWeatherRequest(city_districts_pt[0]);
                forecast_object = await APIRequest.GetJSONForecastRequest(city_districts_pt[0]);
                if (weather_object == null || forecast_object == null)
                {
                    await DisplayAlert("API Error", "Error doing request.", "Ok");
                }

                BindingWeatherInfo();
                IsPresented = false;
            }
            else
            {
                await DisplayAlert("JSONParsing", "No network is available.", "Ok");
            }
        }

        private void DevicePlatform()
        {
            if (Device.RuntimePlatform == Device.iOS)
                Padding = new Thickness(0, 20, 0, 0);
            /*else if (Device.RuntimePlatform == Device.Android)
                Padding = new Thickness(0, 20, 0, 0);
            else if (Device.RuntimePlatform == Device.UWP)
                Padding = new Thickness(0, 20, 0, 0);*/
        }

        private async void AddCitySelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = addCity;
            var selectedItem = (string)picker.SelectedItem;

            if (!selectedItem.Equals(city_districts_pt[0]))
            {
                if (NetworkCheck.IsInternetAsync())
                {
                    weather_object = await APIRequest.GetJSONWeatherRequest(selectedItem);
                    forecast_object = await APIRequest.GetJSONForecastRequest(selectedItem);
                    if (weather_object == null || forecast_object == null) {
                        await DisplayAlert("API Error", "Error doing request.", "Ok");
                    }

                    BindingWeatherInfo();
                    Title = this.weather_object.name + ", Portugal";
                }
                else
                {
                    await DisplayAlert("JSONParsing", "No network is available.", "Ok");
                }


                //string asd = Utils.Utils.hourIcon("");
                //Debug.WriteLine("day: " + asd);
                //Utils.Utils.setFavoriteCities(selectedItem);
                //string savedCity = Utils.Utils.getFavoriteCities();
                //Debug.WriteLine("City saved to EditPreferences: " + savedCity);

            }
            IsPresented = false;
        }

        protected async void ChartForecast_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForecastChart(forecast_object));
        }

        protected async void Forecast_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Forecast(forecast_object));
        }

        private void BindingWeatherInfo()
        {
            //CurrentCity.Text = this.weather_object.name + ", Portugal";
            CurrentTemp.Text = this.weather_object.main.temp.ToString("0");
            CurrentDescription1.Text = Utils.Utils.FirstLetterToUpper(this.weather_object.weather[0].description);
            CurrentDescription2.Text = DateTime.Now.ToString("ddd, dd MMM HH:mm");
            CurrentHumidity.Text = this.weather_object.main.humidity.ToString() + "%";
            CurrentPressure.Text = this.weather_object.main.pressure.ToString() + " hPa";
            double newSpeed = this.weather_object.wind.speed * 3.6;

            CurrentWind.Text = newSpeed.ToString("0") + " km/h";
            CurrentCloudiness.Text = this.weather_object.clouds.all.ToString() + "%";
            CurrentFeelsLike.Text = this.weather_object.main.feels_like.ToString("0") + " ºC";
            CurrentTempMax.Text = this.weather_object.main.temp_max.ToString("0") + " ºC";
            CurrentTempMin.Text = this.weather_object.main.temp_min.ToString("0") + " ºC";

            //Title = 

            if (Utils.Utils.hourIcon().Equals("day"))
            {
                string url = Utils.Utils.retrieveWeatherBackgroundIconDay(this.weather_object.weather[0].main, this.weather_object.weather[0].description);
                WeatherIcon.Source = url;
            } else
            {
                string url = Utils.Utils.retrieveWeatherBackgroundIconNight(this.weather_object.weather[0].main, this.weather_object.weather[0].description);
                WeatherIcon.Source = url;
            }
                
        }

        private void OnMenuClicked(object sender, EventArgs args)
        {
            try
            {
                IsPresented = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
