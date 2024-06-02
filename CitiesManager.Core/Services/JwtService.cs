using CitiesManager.Core.DTO;
using CitiesManager.Core.Identity;
using CitiesManager.Core.ServiceContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Generate a JWT token using the user information and the configuration.
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <returns>AuthenticationResponse</returns>
        public AuthenticationResponse CreateJwtToken(ApplicationUser user)
        {
            // Create a DateTime for the expiration of the token
            DateTime expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));

            // Create the claims for the token
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), // Subject (user id)

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique identifier for the token

                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()), // Issued at (date time)

                new Claim(ClaimTypes.NameIdentifier, user.Email.ToString()), // Unique identifier for the user (email)

                new Claim(ClaimTypes.Name, user.PersonName.ToString()), // Name for the user (person name)
            };

            // Create the security key
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // Create the signing credentials
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create the token
            JwtSecurityToken tokenGenerator = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: expiration,signingCredentials:  signingCredentials);

            // Create the token handler
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(tokenGenerator);

            // Return the token
            return new AuthenticationResponse
            {
                Token = token,
                Email = user.Email,
                PersonName = user.PersonName,
                Expiration = expiration
            };
        }
    }
}
