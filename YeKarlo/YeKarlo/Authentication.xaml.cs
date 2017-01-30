using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace YeKarlo
{
    public partial class Authentication : ContentPage
    {
        string UserName, Password;
        string result;
        string baseUrl = "http://yekarlo.hol.es/Controller/authenticate.php?username=";
        string bUrl = "&password=";
        public Authentication()
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
                    LDatum result = await GetData(UserName, Password);
                    if(result== null)
                    {
                        DisplayAlert("Error", "User Credintials Failed", "Sign In Again");
                    }
                    else
                    {
                        DisplayAlert("Msg", "Authenticated", "Ok");
                    }
                    
                    

                }
            };
        }







        private async Task<LDatum> GetData(string UserName, string Password)
        {
            
            string urls = baseUrl + UserName + bUrl + Password;
            HttpClient wp = new HttpClient();
            string data = await wp.GetStringAsync(urls);
           dynamic jobj = JsonConvert.DeserializeObject<LRootObject>(data);

            //var retData = (string)jobj.data;
            //if (retData == "Login Failed")
            //{
            //    return aaa;
            //}
            //else
            //{
                
            //    var ghfh = (List<LDatum>)jobj.data;
            //    foreach (var asd in ghfh)
            //    {

            //         aaa= asd.id;
            //    }
            //    return aaa;
            //}



            if(jobj.data.ToString() != "Login Failed")
            {
                List<LDatum> ress = new List<LDatum>();
                ress = jobj.data.ToObject<List<LDatum>>();
                return ress[0];
            }
            return null;
            
        }
    }
}
