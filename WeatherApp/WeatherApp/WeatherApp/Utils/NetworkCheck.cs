using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Utils{
    public class NetworkCheck 
    {
        public static async Task<bool> IsInternetAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            {
                // write your code if there is no Internet available
                //await DisplayAlert("Internet", "There isn't internet available to do requests.", "OK");
                return false;
            }
        }
    }
}
