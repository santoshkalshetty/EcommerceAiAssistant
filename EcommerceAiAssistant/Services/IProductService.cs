using EcommerceAiAssistant.DTOs;
using EcommerceAiAssistant.Models;

namespace EcommerceAiAssistant.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();

    Task<Product?> GetProductAsync(int id);

    Task<List<Product>> SearchProductsAsync(
        string keyword);

    Task<List<Product>> GetProductsBelowPriceAsync(
        decimal price);
}