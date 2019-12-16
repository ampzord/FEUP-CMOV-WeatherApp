using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Utils;
using Xamarin.Forms;


namespace WeatherApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            APIRequest.GetJSONWeatherRequest(0, "Porto");


        }
        int count = 0;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";
            DisplayAlert("Title", "Hello World", "Ok");
        }
    }
}
