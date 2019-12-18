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
    public partial class MainPage : MasterDetailPage
    {
        private List<String> districts_pt =
                new List<String>() {
                "Viana do Castelo", "Braga", "Vila Real", "Bragança", "Porto", "Aveiro", "Viseu", "Guarda",
                "Coimbra", "Castelo Branco", "Leiria", "Santarém", "Castelo Branco", "Lisboa", "Portalegre",
                "Évora", "Setúbal", "Beja", "Faro"
        };

        //var picker = new Picker { Title = "Select a monkey", TitleColor = Color.Red };
        //picker.ItemsSource = districts_pt;
        public MainPage()
        {
            InitializeComponent();

            var picker = new Picker { Title = "Select a city", TitleColor = Color.Red };
            picker.SetBinding(Picker.ItemsSourceProperty, "Cities");
            picker.ItemDisplayBinding = new Binding("Name");

            APIRequest.GetJSONForecastRequest("Porto");


        }
        


        /*int count = 0;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";
            DisplayAlert("Title", "Hello World", "Ok");
        }*/

        /*void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                monkeyNameLabel.Text = (string)picker.ItemsSource[selectedIndex];
            }
        }*/

    }
}
