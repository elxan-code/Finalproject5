using Finalproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finalproject.ViewModels
{
    public class VmHome
    {
        public List<Blog> Blog { get; set; }
        public List<Slider> Slider { get; set; }
        public List<Service> Service { get; set; }
        public List<Specials> Specials { get; set; }
        public HomeImage1 HomeImage1 { get; set; }
        public List<FlashDeal2> FlashDeal2 { get; set; }
        public Setting Setting { get; set; }

    }
}
