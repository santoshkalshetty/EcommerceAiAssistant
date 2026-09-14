using EcommerceAiAssistant.Data;
using EcommerceAiAssistant.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAiAssistant.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products
            .Where(p => p.IsActive)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        return await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Product>> SearchProductsAsync(
        string keyword)
    {
        return await _context.Products
            .Where(p =>
                p.IsActive &&
                (p.Name.Contains(keyword) ||
                 p.Category.Contains(keyword)))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Product>>
        GetProductsBelowPriceAsync(decimal price)
    {
        return await _context.Products
            .Where(p =>
                p.IsActive &&
                p.Price <= price)
            .OrderBy(p => p.Price)
            .AsNoTracking()
            .ToListAsync();
    }
}