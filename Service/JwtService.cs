using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppointmentBookingSystem.Service
{
    public class JwtService
    {
          private readonly IConfiguration _configuration;

            public JwtService(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string GenerateToken(int userId, string email)
            {
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var secretKey = jwtSettings["SecretKey"];
                var issuer = jwtSettings["Issuer"];
                var audience = jwtSettings["Audience"];
                var expiresInMinutes = Convert.ToDouble(jwtSettings["ExpiresInMinutes"]);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var token = new JwtSecurityToken(
                    issuer,
                    audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        
    }
}
