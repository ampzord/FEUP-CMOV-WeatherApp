using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts;

namespace WeatherApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForecastChart : ContentPage
    {
        public ForecastChart(ForecastRootObject obj)
        {
            InitializeComponent();
            Title = obj.city.name + ", Portugal";
            List<Entry> chart_entries = new List<Entry>();
            List<Entry> chart_entries_feel = new List<Entry>();

            for (int i = 0; i <= 7; i++)
            {
                float temp_feel = (float)obj.list[i].main.feels_like;
                string tempformattedfeel = temp_feel.ToString() + ""; //missing
                float temp = (float)obj.list[i].main.temp;
                DateTime temp_Date = Convert.ToDateTime(obj.list[i].dt_txt);
                string dateformatted = temp_Date.Hour.ToString() + ":00";
                string tempformmated = temp.ToString() + " ºC";

                var temp_entry = new Entry(temp)
                {
                    //Color = SKColor.Parse("#FF1493"),
                    Label = dateformatted,
                    ValueLabel = tempformmated
                };
                var temp_feel_entry = new Entry(temp)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = dateformatted,
                    ValueLabel = tempformattedfeel
                };

                chart_entries.Add(temp_entry);
                chart_entries_feel.Add(temp_feel_entry);
            }

            ForecastChart2.Chart = new LineChart
            {
                Entries = chart_entries,
                LineMode = LineMode.Straight,
                LabelTextSize = 32f,
            };

            /*ForecastChart2.Chart = new LineChart
            {
                Entries = chart_entries_feel,
                LineMode = LineMode.Straight,
                LabelTextSize = 30f,
            };*/
        }
    }
}