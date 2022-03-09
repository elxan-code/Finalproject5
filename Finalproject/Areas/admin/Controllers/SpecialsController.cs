using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Finalproject.Data;
using Finalproject.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Finalproject.Areas.admin.Controllers
{
    [Area("admin")]
    public class SpecialsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SpecialsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: admin/Specials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specials.ToListAsync());
        }

        // GET: admin/Specials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specials = await _context.Specials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specials == null)
            {
                return NotFound();
            }

            return View(specials);
        }

        // GET: admin/Specials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Specials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Specials specials)
        {

            if (ModelState.IsValid)
            {
                if (specials.ImageFile != null)
                {
                    if (specials.ImageFile.ContentType == "image/jpeg" || specials.ImageFile.ContentType == "image/png")
                    {
                        if (specials.ImageFile.Length <= 3000000)
                        {
                            string FileName = Guid.NewGuid() + "-" + specials.ImageFile.FileName;
                            string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploadsspecials", FileName);
                            using (var stream = new FileStream(FilePath, FileMode.Create))
                            {
                                specials.ImageFile.CopyTo(stream);
                            }
                            specials.Image = FileName;
                            _context.Specials.Add(specials);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));

                        }
                        else
                        {
                            ModelState.AddModelError("", "you can choose only 3 mb image file");
                            return View(specials);
                        }


                    }
                    else
                    {
                        ModelState.AddModelError("", "you can choose only image file");
                        return View(specials);

                    }

                }
                else
                {
                    ModelState.AddModelError("", " choose image file");
                    return View(specials);

                }


            }
            return View(specials);
        }

        // GET: admin/Specials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specials = await _context.Specials.FindAsync(id);
            if (specials == null)
            {
                return NotFound();
            }
            return View(specials);
        }

        // POST: admin/Specials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Specials specials)
        {
            if (ModelState.IsValid)
            {
                if (specials.ImageFile != null)
                {
                    if (specials.ImageFile.ContentType == "image/jpeg" || specials.ImageFile.ContentType == "image/png")
                    {
                        if (specials.ImageFile.Length <= 3000000)
                        {
                            string olddata = Path.Combine(_webHostEnvironment.WebRootPath, "Uploadsspecials", specials.Image);
                            if (System.IO.File.Exists(olddata))
                            {
                                System.IO.File.Delete(olddata);
                            }
                            string FileName = Guid.NewGuid() + "-" + specials.ImageFile.FileName;
                            string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploadsspecials", FileName);
                            using (var stream = new FileStream(FilePath, FileMode.Create))
                            {
                                specials.ImageFile.CopyTo(stream);
                            }
                            specials.Image = FileName;
                            _context.Specials.Update(specials);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));

                        }
                        else
                        {
                            ModelState.AddModelError("", "you can choose only 3 mb image file");
                            return View(specials);
                        }


                    }
                    else
                    {
                        ModelState.AddModelError("", "you can choose only image file");
                        return View(specials);

                    }

                }
                else
                {
                    ModelState.AddModelError("", " choose image file");
                    return View(specials);

                }

            }

            return View(specials);
        }

        // GET: admin/Specials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specials = await _context.Specials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specials == null)
            {
                return NotFound();
            }

            return View(specials);
        }

        // POST: admin/Specials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specials = await _context.Specials.FindAsync(id);
            string olddata = Path.Combine(_webHostEnvironment.WebRootPath, "Uploadsspecials", specials.Image);
            if (System.IO.File.Exists(olddata))
            {
                System.IO.File.Delete(olddata);
            }
            _context.Specials.Remove(specials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialsExists(int id)
        {
            return _context.Specials.Any(e => e.Id == id);
        }
    }
}
