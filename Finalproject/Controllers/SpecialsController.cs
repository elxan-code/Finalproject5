using Finalproject.Data;
using Finalproject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finalproject.Controllers
{
    public class SpecialsController : Controller
    {

        private readonly AppDbContext _context;
        public SpecialsController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            VmHome model = new VmHome()
            {
                Specials = _context.Specials.ToList(),
            };

            return View(model);
        }
        public IActionResult SpecialDeatails(int? id)
        {
            return View(_context.Specials.Find(id));
        }
    }
}
