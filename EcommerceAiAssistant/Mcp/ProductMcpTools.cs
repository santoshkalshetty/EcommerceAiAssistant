using System.ComponentModel;
using EcommerceAiAssistant.Services;
using ModelContextProtocol.Server;

namespace EcommerceAiAssistant.Mcp;

[McpServerToolType]
public class ProductMcpTools
{
    private readonly IProductService _productService;

    public ProductMcpTools(
        IProductService productService)
    {
        _productService = productService;
    }

    [McpServerTool]
    [Description(
        "Get complete information about a product using its ID.")]
    public async Task<object> GetProduct(
        [Description("The product ID")]
        int productId)
    {
        var product =
            await _productService.GetProductAsync(productId);

        if (product == null)
        {
            return new
            {
                success = false,
                message = "Product not found"
            };
        }

        return new
        {
            success = true,
            product.Id,
            product.Name,
            product.Category,
            product.Price,
            product.StockQuantity
        };
    }

    [McpServerTool]
    [Description(
        "Search products by product name or category.")]
    public async Task<object> SearchProducts(
        [Description(
            "Product name or category")]
        string keyword)
    {
        return await _productService
            .SearchProductsAsync(keyword);
    }

    [McpServerTool]
    [Description(
        "Find products whose price is less than or equal to the specified amount.")]
    public async Task<object> GetProductsBelowPrice(
        [Description(
            "Maximum product price")]
        decimal price)
    {
        return await _productService
            .GetProductsBelowPriceAsync(price);
    }
}