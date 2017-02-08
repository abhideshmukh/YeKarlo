using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YeKarlo.Views.Drawers.EventF.EventItemsF
{
    public partial class EventItems : ContentPage
    {
        string baseaddr = "zzzzzzzzzzzz";
        string locl, locla, timp,id,uid;
        public EventItems()
        {
            InitializeComponent(); 
            btn.Clicked += async (s, e) =>
            {
                id = YeKarlo.Views.Drawers.EventF.Constants.MyDetails.EventId;
                uid = YeKarlo.Auth.Constants.MyDetails.id;
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                locl = Convert.ToString(position.Longitude);
                locla = Convert.ToString(position.Latitude);
                timp = DateTime.Now.ToString();
                var result = await PushData();
            };

        }



        private async Task<bool> PushData()
        {
            string urls = baseaddr+ "event_id=" + id + "&user_id="+ uid + "&loc_lat=" + locla + "&loc_long=" + locl + "&CurrentTimeStamp=" + timp;
            HttpClient webClient = new HttpClient();
            string aaa = await webClient.GetStringAsync(urls);
            return true;
        }
    }
}
