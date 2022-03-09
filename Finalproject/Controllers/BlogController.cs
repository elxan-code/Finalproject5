using Finalproject.Data;
using Finalproject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finalproject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;

        }


        public IActionResult Index()
        {
            VmHome model = new VmHome()
            {        
                Blog = _context.Blogs.ToList(),
            };

            return View(model);
        }
        public IActionResult Blogdetails(int? id)
        {

            return View(_context.Blogs.Find(id));

        }

    }
}
