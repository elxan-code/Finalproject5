using Finalproject.Data;
using Finalproject.Models;
using Finalproject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Finalproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;

        }



        public IActionResult Index()
        {
            VmHome model = new VmHome()
            {
                Slider = _context.Sliders.ToList(),
                Service = _context.Services.ToList(),
                HomeImage1 = _context.HomeImage1s.FirstOrDefault(),
                FlashDeal2 = _context.FlashDeal2s.ToList(),
                Blog = _context.Blogs.ToList(),
                Specials = _context.Specials.ToList()
              

            };

            return View(model);



        }



        }
}
