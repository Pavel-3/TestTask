using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Data;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using TestTask.Enums;

namespace TestTask.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<User?> GetUserAsync()
        {
            User? user = await _context.Users
                .OrderByDescending(user => user.Orders.Count())
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> users = await _context.Users
                .Where(user => user.Status == UserStatus.Inactive)
                .ToListAsync();
            return users;
        }
    }
}
