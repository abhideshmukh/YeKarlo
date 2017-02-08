using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YeKarlo.Views
{
    public partial class DrawerPage : ContentPage
    {

        public Action<ContentPage> OnMenuSelect
        {
            get;
            set;
        }

        public DrawerPage()
        {
            InitializeComponent();
            img.Source = "icon.png";


            Title = "DrawerPage";

            var categories = new List<Category>()
            {
                new Category("Home Page",   () =>new Views.Drawers.HomePage(),"icon.png"),
                new Category("Logout",   () =>new Auth.Authentications(),"icon.png"),
                new Category("Events", ()=> new Drawers.EventF.Events(),"icon.png")

            };
            listed.BackgroundColor = Color.White;

            myName.Text = "Ye Karlo";
            listed.ItemsSource = categories;

            listed.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (OnMenuSelect != null)
                {
                    var category = (Category)e.SelectedItem;
                    if (category.Name == "Logout")
                    {
                        App.Current.MainPage = new NavigationPage(new YeKarlo.Auth.Authentications());
                    }

                    var categoryPage = category.PageFn();
                    OnMenuSelect(categoryPage);
                }
            };

        }
    }
}
