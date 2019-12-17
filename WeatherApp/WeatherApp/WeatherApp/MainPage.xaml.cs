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

            APIRequest.GetJSONForecastRequest("Porto");


        }
        int count = 0;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";
            DisplayAlert("Title", "Hello World", "Ok");
        }

        List<String> districts_pt = 
            new List<String>() { 
                "Viana do Castelo", "Braga", "Vila Real", "Bragança", "Porto", "Aveiro", "Viseu", "Guarda", 
                "Coimbra", "Castelo Branco", "Leiria", "Santarém", "Castelo Branco", "Lisboa", "Portalegre", 
                "Évora", "Setúbal", "Beja", "Faro" 
            };
    }
}
