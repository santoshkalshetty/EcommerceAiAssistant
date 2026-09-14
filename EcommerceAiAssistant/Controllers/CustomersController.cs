using EcommerceAiAssistant.Data;
using EcommerceAiAssistant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAiAssistant.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<Customer>>> GetAll(CancellationToken cancellationToken) =>
        Ok(await dbContext.Customers.AsNoTracking().OrderBy(customer => customer.Name).ToListAsync(cancellationToken));
}