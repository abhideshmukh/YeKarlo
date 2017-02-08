using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace YeKarlo.Auth
{
    public partial class Authentications : ContentPage
    {
        string UserName, Password;
        //string baseUrl = "xxxxxxxxxxxxxxxxxxxx";
        string bUrl = "&password=";
        
        public Authentications()
        {

            InitializeComponent();
            btnLogin.Clicked += async (s, e) =>
            {
                UserName = usrName.Text;
                Password = pass.Text;
                if(UserName==null && Password==null)
                {
                    DisplayAlert("Error", "Please Insert User Name and Password", "Ok");
                }
                else
                {
                    Result result = await GetData(UserName, Password);
                    if(result== null)
                    {
                        DisplayAlert("Error", "User Credintials Failed", "Sign In Again");
                    }
                    else
                    {
                        Constants.MyDetails = result;
                        App.Current.MainPage = new Views.MenuPage();
                        //App.Current.MainPage = new Views.Drawers.EventF.Events();
                        //await Navigation.PushAsync(new Views.Drawers.EventF.Events());

                    }
                    
                    
                }
            };
        }



        public async Task<Result> GetData(string UserName, string Password)
        {
            
            string urls = baseUrl + UserName + bUrl + Password;
            HttpClient wp = new HttpClient();
            string data = await wp.GetStringAsync(urls);
            dynamic jobj = JsonConvert.DeserializeObject<RootObject>(data);
            if(jobj.Result.ToString() != "Login Failed")
            {
                List<Result> ress = new List<Result>();
                ress = jobj.Result.ToObject<List<Result>>();
                return ress[0];
            }


            return null;
            
        }
    }
}
