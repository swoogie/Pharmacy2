using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy2.Infra;
using Pharmacy2.Models;

namespace Pharmacy2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DrugsController : Controller
    {

        private readonly DataContext _context;

        public DrugsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Drugs.Count() / pageSize);

            return View(await _context.Drugs.OrderByDescending(p => p.Id)
                .Include(p => p.Category)
                .Skip((p - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync());
        }
    }
}
