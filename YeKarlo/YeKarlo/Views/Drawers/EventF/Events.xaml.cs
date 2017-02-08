using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YeKarlo.Views.Drawers.EventF
{
    public partial class Events : ContentPage
    {
        string baseurl = "zzzzzzzzzzzzzzzz";
        string id;
        public Events()
        {
            InitializeComponent();
            //id = Auth.Constants.MyDetails.id;
            id = "1";
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var asd = await GetEvents();
                foreach(var ttt in asd)
                {
                    Constants.MyDetails = ttt;
                }
                EventList.ItemsSource = asd;
            });
        }






        async void OnTapGestureRecognizer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventItemsF.EventItems());
            
        }

        private async Task<List<Result>> GetEvents()
        {
            string urls = baseurl + id;
            HttpClient ws = new HttpClient();
            string result = await ws.GetStringAsync(urls);
            var jObj = JsonConvert.DeserializeObject<RootObject>(result);
            List<Result> aaa = jObj.Result;
            
            return aaa;
            
        }
    }
}
