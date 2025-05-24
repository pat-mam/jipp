using Microsoft.AspNetCore.Mvc;
using Music_Shop.Data;
using Music_Shop.Models;

namespace Music_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private string CartSessionKey =>
            "Cart_" + (HttpContext.Session.GetString("User") ?? "guest");


        public CartController(AppDbContext context)
        {
            _context = context;
        }

        private List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey);
            return cart ?? new List<CartItem>();
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        public IActionResult Add(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null || product.StockQuantity == 0)
                return NotFound();

            var cart = GetCart();
            var item = cart.FirstOrDefault(i => i.ProductId == id);
            if (item != null)
            {
                if (item.Quantity < product.StockQuantity)
                    item.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { ProductId = id, Product = product, Quantity = 1 });
            }

            SaveCart(cart);

            // ✅ TU dodajemy komunikat
            TempData["Message"] = $"Masz teraz {cart.Sum(i => i.Quantity)} produktów w koszyku.";

            return RedirectToAction("Index", "Store");
        }


        public IActionResult Remove(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(i => i.ProductId == id);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        //public IActionResult Checkout()
        //{
        //    var cart = GetCart();
        //    decimal total = 0;

        //    foreach (var item in cart)
        //    {
        //        var product = _context.Products.Find(item.ProductId);
        //        if (product != null && product.StockQuantity >= item.Quantity)
        //        {
        //            product.StockQuantity -= item.Quantity;
        //            total += item.Quantity * product.Price;
        //        }
        //    }

        // GET: pokazuje podsumowanie koszyka i pyta o potwierdzenie
        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = GetCart();
            ViewBag.Total = cart.Sum(i => i.Quantity * i.Product.Price);
            return View(cart);
        }

        // POST: finalizuje zakup po potwierdzeniu
        [HttpPost]
        public IActionResult CheckoutConfirm()
        {
            var cart = GetCart();
            decimal total = 0;

            foreach (var item in cart)
            {
                var product = _context.Products.Find(item.ProductId);
                if (product != null && product.StockQuantity >= item.Quantity)
                {
                    product.StockQuantity -= item.Quantity;
                    total += item.Quantity * product.Price;
                }
            }

            _context.SaveChanges();
            HttpContext.Session.Remove(CartSessionKey);
            ViewBag.Total = total;
            return View("CheckoutSuccess");
        




        //_context.SaveChanges();
        //    HttpContext.Session.Remove(CartSessionKey);
        //    ViewBag.Total = total;
        //    return View();
        }
    }
}
