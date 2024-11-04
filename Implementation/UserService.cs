using AppointmentBookingSystem.DTO;
using AppointmentBookingSystem.Interface;
using AppointmentBookingSystem.Models;
using System.Text;
using System.Security.Cryptography;

namespace AppointmentBookingSystem.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterUserAsync(UserRegistrationDTO userDTO)
        {
            // Hash password, map DTO to User entity, and other business logic
            var user = new User { Email = userDTO.Email, PasswordHash = HashPassword(userDTO.Password) };
            return await _userRepository.AddUserAsync(user);
        }

        public async Task<User> LoginUserAsync(UserLoginDTO loginDTO)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDTO.Email);
            if (user != null && VerifyPassword(loginDTO.Password, user.PasswordHash))
            {
                return user;
            }
            return null; // Or handle failed login attempt
        }

        private string HashPassword(string password)
        {
            // Hashing logic here, e.g., using SHA256 or a library like BCrypt
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify password logic, for example by rehashing and comparing
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var inputHash = Convert.ToBase64String(hashedBytes);
                return inputHash == hashedPassword;
            }
        }


    }
}
