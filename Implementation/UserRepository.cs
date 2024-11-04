using AppointmentBookingSystem.Data;
using AppointmentBookingSystem.Interface;
using AppointmentBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBookingSystem.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingContext _context;

        public UserRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
