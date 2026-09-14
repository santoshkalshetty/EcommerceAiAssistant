using EcommerceAiAssistant.Models;

namespace EcommerceAiAssistant.Services;

public interface IOrderService
{
    Task<Order?> GetOrderAsync(int id);

    Task<List<Order>> GetCustomerOrdersAsync(
        int customerId);
}