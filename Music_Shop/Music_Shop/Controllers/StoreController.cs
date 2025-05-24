using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_Shop.Data;
using Music_Shop.Models;

namespace Music_Shop.Controllers
{
    public class StoreController : Controller
    {
        private readonly AppDbContext _context;

        public StoreController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Store/
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // GET: /Store/Create
        [HttpGet]
        public IActionResult Create()
        {
            var user = HttpContext.Session.GetString("User");
            if (user != "admin")
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // POST: /Store/Create
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var user = HttpContext.Session.GetString("User");
            if (user != "admin")
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = HttpContext.Session.GetString("User");
            if (user != "admin")
                return RedirectToAction("Index");

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: /Store/Edit/5
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var user = HttpContext.Session.GetString("User");
            if (user != "admin")
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: /Store/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = HttpContext.Session.GetString("User");
            if (user != "admin")
                return RedirectToAction("Index");

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: /Store/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = HttpContext.Session.GetString("User");
            if (user != "admin")
                return RedirectToAction("Index");

            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}