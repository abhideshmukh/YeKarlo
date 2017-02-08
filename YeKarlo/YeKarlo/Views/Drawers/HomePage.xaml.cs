using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace YeKarlo.Views.Drawers
    

{
    
    public partial class HomePage : ContentPage
    {
        string getCourseApi = "yyyyyyyyyyyyyy";
         public HomePage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                

                var getData = await GJson();
                lView.ItemsSource = getData;

                string myId = Auth.Constants.MyDetails.id;

            });
        }


        private async Task<List<Datum>> GJson()
        {
            HttpClient webClient = new HttpClient();
            string result = await webClient.GetStringAsync(getCourseApi);


            var jObj = JsonConvert.DeserializeObject<RootObject>(result);
            List<Datum> asd = jObj.data;

            return asd;
        }


    }
}
