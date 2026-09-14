using EcommerceAiAssistant.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAiAssistant.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext dbContext)
    {
        if (await dbContext.Products.AnyAsync())
        {
            return;
        }

        dbContext.Products.AddRange(
            new Product { Name = "Wireless Headphones", Category = "Audio", Price = 129.99m, StockQuantity = 25, IsActive = true, CreatedDate = DateTime.UtcNow },
            new Product { Name = "Mechanical Keyboard", Category = "Accessories", Price = 89.50m, StockQuantity = 40, IsActive = true, CreatedDate = DateTime.UtcNow });

        dbContext.Customers.Add(new Customer { Name = "Demo Customer", Email = "demo@example.com" });
        await dbContext.SaveChangesAsync();
    }
}