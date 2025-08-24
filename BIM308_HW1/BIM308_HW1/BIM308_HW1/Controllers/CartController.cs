using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BIM308_HW1.Models;

namespace BIM308_HW1.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Request.Cookies["UserInfo"]))
            {
                return View("Error", new ErrorViewModel { Message = "Please log in to view your cart." });
            }

            var cart = HttpContext.Session.GetObject<List<int>>("Cart") ?? new List<int>();
            return View(cart);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetObject<List<int>>("Cart") ?? new List<int>();
            cart.Remove(id);
            HttpContext.Session.SetObject("Cart", cart);
            return RedirectToAction("Index");

        }
    }
}