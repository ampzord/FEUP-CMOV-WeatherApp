using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp2.Utils
{
    public class NetworkCheck
    {
        public static Boolean IsInternetAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            {
                // write your code if there is no Internet available
                //await DisplayAlert("Internet", "There isn't internet available to do requests.", "OK");
                Debug.WriteLine("There isn't internet available to do requests.");
                return false;
            }
        }
    }
}
