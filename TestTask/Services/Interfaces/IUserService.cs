using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User?> GetUserAsync();

        public Task<List<User>> GetUsersAsync();
    }
}
