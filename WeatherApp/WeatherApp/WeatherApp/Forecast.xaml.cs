using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.Model;

namespace WeatherApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Forecast : ContentPage
    {
        private List<double> temp_average;
        private List<double> temp_max_average; 
        private List<double> temp_min_average; 
        private List<double> wind_average; 
        //private List<double> precipitation_average;
        private List<int> humidity_average;

        private ForecastRootObject obj;
        public Forecast(ForecastRootObject obj)
        {

            this.obj = obj;
            InitializeComponent();
            temp_average = new List<double>();
            temp_max_average = new List<double>();
            temp_min_average = new List<double>();
            wind_average = new List<double>();
            //precipitation_average = new List<double>();
            humidity_average = new List<int>();

            Title = obj.city.name + ", Portugal";

            for (int i=0; i <= 7; i++)
            {
                string temp_temp = obj.list[i].main.temp.ToString("0");
                double value_temp = Convert.ToDouble(temp_temp);

                string temp_max_temp = obj.list[i].main.temp_max.ToString("0");
                double value_max_temp = Convert.ToDouble(temp_max_temp);

                string temp_min_temp = obj.list[i].main.temp_min.ToString("0");
                double value_min_temp = Convert.ToDouble(temp_min_temp);

                string temp_wind = obj.list[i].wind.speed.ToString("0");
                double value_wind = Convert.ToDouble(temp_wind);

                //string temp_precipitation = obj.list[i].main.temp.ToString("0");
                //double value_precipitation = Convert.ToDouble(temp_precipitation);

                string temp_humidity = obj.list[i].main.humidity.ToString();
                int value_humidity = Convert.ToInt32(temp_humidity);

                temp_average.Add(value_temp);
                temp_max_average.Add(value_max_temp);
                temp_min_average.Add(value_min_temp);
                wind_average.Add(value_wind);
                //precipitation_average.Add(value_precipitation);
                humidity_average.Add(value_humidity);
            }

            BindingForecastInfo();



        }

        private void BindingForecastInfo()
        {
            DateTime today = DateTime.Now;
            DateTime tomorrow = today.AddDays(1);
            double temp_avg = temp_average.Average();
            double temp_max_avg = temp_max_average.Average();
            double temp_min_avg = temp_min_average.Average();
            double wind_avg = wind_average.Average();
            double humidity_avg = humidity_average.Average();

            ForecastMinTemp.Text = temp_min_avg.ToString("0");
            ForecastCurrentTemp.Text = temp_avg.ToString("0");
            //ForecastMaxTemp.Text = temp_max_avg.ToString("0");
            ForecastCurrentDescription1.Text = Utils.Utils.FirstLetterToUpper(obj.list[0].weather[0].description);
            ForecastCurrentDescription2.Text = tomorrow.ToString("ddd, dd MMM HH:mm");

            if (Utils.Utils.hourIcon().Equals("day"))
            {
                string url = Utils.Utils.retrieveWeatherBackgroundIconDay(obj.list[0].weather[0].main, obj.list[0].weather[0].description);
                WeatherIcon.Source = url;
            }
            else
            {
                string url = Utils.Utils.retrieveWeatherBackgroundIconNight(obj.list[0].weather[0].main, obj.list[0].weather[0].description);
                WeatherIcon.Source = url;
            }
        }
    }
}