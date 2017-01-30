using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YeKarlo
{
    public partial class Courses : ContentPage
    {
        string getCourseApi = "http://yekarlo.hol.es/Controller/GetCourses.php";
        public Courses()
        {
            InitializeComponent();
          
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () => {

                var getData = await GJson();
                lView.ItemsSource = getData;

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
