using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Data;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Order?> GetOrderAsync()
        {
            Order? order = await _context.Orders
                .OrderByDescending(order=>order.Quantity*order.Price)
                .FirstOrDefaultAsync();
            return order;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            List<Order> orders = await _context.Orders
                .Where(order => order.Quantity>10)
                .ToListAsync();
            return orders;
        }
    }
}
