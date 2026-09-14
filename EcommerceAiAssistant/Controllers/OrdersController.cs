using EcommerceAiAssistant.Models;
using EcommerceAiAssistant.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAiAssistant.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<Order>>> GetByCustomer([FromQuery] int customerId) =>
        Ok(await orderService.GetCustomerOrdersAsync(customerId));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetById(int id)
    {
        var order = await orderService.GetOrderAsync(id);
        return order is null ? NotFound() : Ok(order);
    }
}