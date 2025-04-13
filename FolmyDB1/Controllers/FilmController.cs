using Microsoft.AspNetCore.Mvc;
using FilmDB.Models;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            var exampleFilm = new FilmModel
            {
                ID = 1,
                Title = "Matrix",
                Year = 1999
            };

            return View(exampleFilm); // Na razie przekazujemy przykładowy film
        }
    }
}