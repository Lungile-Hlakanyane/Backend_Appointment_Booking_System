using AppointmentBookingSystem.Data;
using AppointmentBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using AppointmentBookingSystem.Service;
using AppointmentBookingSystem.DTO;
using AppointmentBookingSystem.Interface;

namespace AppointmentBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDTO userDTO)
        {
            var user = await _userService.RegisterUserAsync(userDTO);
            return user != null ? Ok(user) : BadRequest("Registration failed");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO loginDTO)
        {
            var user = await _userService.LoginUserAsync(loginDTO);
            return user != null ? Ok("JWT Token Here") : Unauthorized("Invalid credentials");
        }
    }
}
