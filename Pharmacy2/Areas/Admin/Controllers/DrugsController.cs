using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmacy2.Infra;
using Pharmacy2.Models;
using System.Net.Http.Headers;

namespace Pharmacy2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DrugsController : Controller
    {

        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DrugsController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Drugs.Count() / pageSize);

            return View(await _context.Drugs.OrderByDescending(d => d.Id)
                .Include(d => d.Category)
                .Skip((p - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync());
        }

        public async Task<IActionResult> FetchOrders(int p = 1)
        {
            int pageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Orders.Count() / pageSize);

            return View(await _context.Orders.OrderByDescending(d => d.Id)
                .Skip((p - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Drug drug)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", drug.CategoryId);

            if (ModelState.IsValid)
            {
                drug.Slug = drug.Name.ToLower().Replace(" ", "-");

                var slug = await _context.Drugs.FirstOrDefaultAsync(d => d.Slug == drug.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The product already exists.");
                    return View(drug);
                }

                if(drug.ImageUpload!= null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/medicine");
                    string imageName = Guid.NewGuid().ToString() + "_" + drug.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);

                    await drug.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    drug.Image = imageName;
                }

                _context.Add(drug);
                await _context.SaveChangesAsync();


                TempData["Success"] = "The product has been created!";

                return RedirectToAction("Index");
            }

            return View(drug);
        }

        public async Task<IActionResult> Edit(long id)
        {
            Drug drug = await _context.Drugs.FindAsync(id);
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", drug.CategoryId);


            return View(drug);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Drug drug)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", drug.CategoryId);

            if (ModelState.IsValid)
            {
                drug.Slug = drug.Name?.ToLower().Replace(" ", "-");

                var slug = await _context.Drugs.FirstOrDefaultAsync(d => d.Slug == drug.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The product already exists.");
                    return View(drug);
                }

                if (drug.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/medicine");
                    string imageName = Guid.NewGuid().ToString() + "_" + drug.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);

                    await drug.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    drug.Image = imageName;
                }

                _context.Update(drug);
                await _context.SaveChangesAsync();


                TempData["Success"] = "The product has been edited!";

                return RedirectToAction("Index");
            }

            return View(drug);
        }

        public async Task<IActionResult> Delete(long id)
        {
            Drug drug = await _context.Drugs.FindAsync(id);

            if (!string.Equals(drug.Image, "noimage.png"))
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                string oldImagePath = Path.Combine(uploadsDir, drug.Image);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _context.Drugs.Remove(drug);
            await _context.SaveChangesAsync();

            TempData["Success"] = "The product has been deleted!";

            return RedirectToAction("Index");
        }
    }
}
