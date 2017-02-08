using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeKarlo.Views.Drawers.EventF
{
    public class RootObject
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public List<Result> Result { get; set; }
        public int ResultCount { get; set; }
    }
}
