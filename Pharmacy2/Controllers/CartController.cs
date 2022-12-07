using Microsoft.AspNetCore.Mvc;
using Pharmacy2.Infra;
using Pharmacy2.Models;
using Pharmacy2.Models.ViewModels;

namespace Pharmacy2.Controllers
{
    public class CartController : Controller
    {

        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart")?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                total = cart.Sum(x => x.Quantity * x.Price)
            };

            return View(cartVM);
        }

        public async Task<IActionResult> Add(long id)
        {
            Drug drug = await _context.Drugs.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(p => p.DrugId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(drug));

            } 
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has been added!";

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                total = cart.Sum(x => x.Quantity * x.Price)
            };

            return Redirect(Request.Headers["Referer"].ToString());

        }

        public async Task<IActionResult> Decrease(long id)
        {
            Drug drug = await _context.Drugs.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(p => p.DrugId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;
            }
            else
            {
                cart.RemoveAll(p => p.DrugId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }



            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Remove(long id)
        {
            Drug drug = await _context.Drugs.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.DrugId == id);
                           
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            
            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");

        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }
    }
}
