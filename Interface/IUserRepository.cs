using AppointmentBookingSystem.Models;

namespace AppointmentBookingSystem.Interface
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
}
