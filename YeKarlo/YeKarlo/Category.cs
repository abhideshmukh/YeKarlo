using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YeKarlo
{
    public class Category
    {

        public string Name
        {
            get;
            set;
        }
        public string Icon
        {
            get;
            set;
        }
        public Func<ContentPage> PageFn
        {
            get;
            set;
        }

        public Category(string name, Func<ContentPage> pageFn, string icon)
        {
            Name = name;
            PageFn = pageFn;
            Icon = icon;
        }



    }
}
