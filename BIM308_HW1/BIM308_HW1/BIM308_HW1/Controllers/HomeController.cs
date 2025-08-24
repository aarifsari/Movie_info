using Microsoft.AspNetCore.Mvc;
using BIM308_HW1.Models;
using Microsoft.AspNetCore.Http.Extensions;

namespace BIM308_HW1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var movies = HttpContext.Session.GetObject<List<BIM308_HW1.Models.Movie>>("Movies");
            if (movies == null)
            {
                movies = new List<BIM308_HW1.Models.Movie>
{
    new BIM308_HW1.Models.Movie { MovieID = 1, Title = "X-Men: The Last Stand", Director = "Brett Ratner", Stars = new[] { "Patrick Stewart", "Hugh Jackman", "Halle Berry" }, ReleaseYear = 2006, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMThmOWE3OWEtODJmNC00ZDEzLTk4MWUtNzEzM2RiNmJiZmU3XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg" },
    new BIM308_HW1.Models.Movie { MovieID = 2, Title = "Spider Man 2", Director = "Sam Raimi", Stars = new[] { "Tobey Maguire", "Kirsten Dunst", "Alfred Molina" }, ReleaseYear = 2004, ImageUrl = "https://m.media-amazon.com/images/M/MV5BNGQ0YTQyYTgtNWI2YS00NTE2LWJmNDItNTFlMTUwNmFlZTM0XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg" },
    new BIM308_HW1.Models.Movie { MovieID = 3, Title = "Spider Man 3", Director = "Sam Raimi", Stars = new[] { "Tobey Maguire", "Kirsten Dunst", "Topher Grace" }, ReleaseYear = 2007, ImageUrl = "https://m.media-amazon.com/images/M/MV5BODE2NzNhMDctYjUzMC00Y2M5LWI2Y2EtODJkZTFjN2Y5ODlmXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg" },
    new BIM308_HW1.Models.Movie { MovieID = 4, Title = "Valkyrie", Director = "Bryan Singer", Stars = new[] { "Tom Cruise", "Bill Nighy", "Carice van Houten" }, ReleaseYear = 2008, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/7/76/Valkyrie_film_afi%C5%9Fi.jpg" },
    new BIM308_HW1.Models.Movie { MovieID = 5, Title = "Gladiator", Director = "Ridley Scott", Stars = new[] { "Russell Crowe", "Joaquin Phoenix", "Connie Nielsen" }, ReleaseYear = 2000, ImageUrl = "https://upload.wikimedia.org/wikipedia/tr/8/8d/Gladiator_ver1.jpg" }
};
                HttpContext.Session.SetObject("Movies", movies);
            }
            return View(movies);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserInfo");
            return RedirectToAction("Index");

        }

    }

}