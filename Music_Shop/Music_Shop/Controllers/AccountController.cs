using Microsoft.AspNetCore.Mvc;
using Music_Shop.Models;

namespace Music_Shop.Controllers
{
    public class AccountController : Controller
    {
        // Prosta lista użytkowników
        private static readonly List<User> Users = new()
        {
            new User { Username = "admin", Password = "admin" },
            new User { Username = "user", Password = "user" }
        };

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("User", user.Username);
                return RedirectToAction("Index", "Store");
            }

            ViewBag.Error = "Nieprawidłowa nazwa użytkownika lub hasło";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Store");
        }
    }
}