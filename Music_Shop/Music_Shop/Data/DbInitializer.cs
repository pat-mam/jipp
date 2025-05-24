using Music_Shop.Models;

namespace Music_Shop.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Products.Any())
            return; // baza już zawiera dane

        var products = new Product[]
        {
            new Product { Name = "Gitara klasyczna", Price = 499.99M, StockQuantity = 10 },
            new Product { Name = "Keyboard Yamaha", Price = 899.00M, StockQuantity = 5 },
            new Product { Name = "Perkusja elektroniczna", Price = 1299.00M, StockQuantity = 3 },
            new Product { Name = "Skrzypce", Price = 750.50M, StockQuantity = 7 },
            new Product { Name = "Mikrofon studyjny", Price = 299.99M, StockQuantity = 12 }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}