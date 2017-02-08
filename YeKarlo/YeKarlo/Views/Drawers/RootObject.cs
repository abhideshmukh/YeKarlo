using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeKarlo.Views.Drawers
{
    public class RootObject
    {
        public int status { get; set; }
        public string status_message { get; set; }
        public List<Datum> data { get; set; }
       
    }
}
