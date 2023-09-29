using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order?> GetOrderAsync();

        public Task<List<Order>> GetOrdersAsync();
    }
}
