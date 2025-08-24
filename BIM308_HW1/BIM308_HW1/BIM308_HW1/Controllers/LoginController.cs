using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string firstName, string lastName)
    {
        if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
        {
            var userInfo = $"{firstName},{lastName}";
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddMonths(1) 
            };
            Response.Cookies.Append("UserInfo", userInfo, cookieOptions);
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
}