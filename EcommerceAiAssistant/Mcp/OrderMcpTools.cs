using System.ComponentModel;
using EcommerceAiAssistant.Services;
using ModelContextProtocol.Server;

namespace EcommerceAiAssistant.Mcp;

[McpServerToolType]
public class OrderMcpTools
{
    private readonly IOrderService _orderService;

    public OrderMcpTools(
        IOrderService orderService)
    {
        _orderService = orderService;
    }

    [McpServerTool]
    [Description(
        "Get complete information about a customer order.")]
    public async Task<object> GetOrder(
        [Description("The order ID")]
        int orderId)
    {
        var order =
            await _orderService.GetOrderAsync(orderId);

        if (order == null)
        {
            return new
            {
                success = false,
                message = "Order not found"
            };
        }

        return new
        {
            success = true,
            order.Id,
            order.OrderDate,
            order.Status,
            order.TotalAmount,
            Customer = order.Customer?.Name,
            Items = order.OrderItems.Select(x => new
            {
                Product = x.Product?.Name,
                x.Quantity,
                x.UnitPrice
            })
        };
    }

    [McpServerTool]
    [Description(
        "Get all orders belonging to a customer.")]
    public async Task<object> GetCustomerOrders(
        [Description("The customer ID")]
        int customerId)
    {
        return await _orderService
            .GetCustomerOrdersAsync(customerId);
    }
}