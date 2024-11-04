using AppointmentBookingSystem.DTO;
using AppointmentBookingSystem.Models;

namespace AppointmentBookingSystem.Interface
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(UserRegistrationDTO userDTO);
        Task<User> LoginUserAsync(UserLoginDTO loginDTO);
    }
}
