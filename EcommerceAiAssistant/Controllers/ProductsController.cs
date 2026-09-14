using EcommerceAiAssistant.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAiAssistant.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(
        IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products =
            await _service.GetProductsAsync();

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product =
            await _service.GetProductAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] string keyword)
    {
        var products =
            await _service.SearchProductsAsync(keyword);

        return Ok(products);
    }
}