using AppointmentBookingSystem.Models;

namespace AppointmentBookingSystem.Interface
{
    public interface IUserInterface
    {
        Task<User> RegisterUserAsync(DTO.UserRegistrationDTO userDTO);
        Task<User> LoginUserAsync(DTO.UserLoginDTO loginDTO);
    }
}
