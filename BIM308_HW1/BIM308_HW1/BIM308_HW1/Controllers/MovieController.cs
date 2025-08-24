using Microsoft.AspNetCore.Mvc;
using BIM308_HW1.Models;
using System.Collections.Generic;

namespace BIM308_HW1.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Info(int? id)
        {
            var movies = HttpContext.Session.GetObject<List<BIM308_HW1.Models.Movie>>("Movies");
            if (!id.HasValue)
            {
                return View("Error", new ErrorViewModel { Message = "Please specify a movie ID." });
            }
            if (movies == null || !movies.Any(m => m.MovieID == id))
            {
                return View("Error", new ErrorViewModel { Message = "Invalid Movie ID!!!" });
            }
            var movie = movies.FirstOrDefault(m => m.MovieID == id);
            ViewBag.IsLoggedIn = !string.IsNullOrEmpty(HttpContext.Request.Cookies["UserInfo"]);
            return View(movie);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var cart = HttpContext.Session.GetObject<List<int>>("Cart") ?? new List<int>();
            var isAdded = !cart.Contains(id);
            if (isAdded)
            {
                cart.Add(id);
                HttpContext.Session.SetObject("Cart", cart);
            }
            return Json(new { success = isAdded });
        }
    }
}