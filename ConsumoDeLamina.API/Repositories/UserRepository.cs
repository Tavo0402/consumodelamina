using ConsumoDeLamina.API.Repositories.IRepository;
using ConsumoDeLamina.Data;
using ConsumoDeLamina.Entities.DTOs;
using ConsumoDeLamina.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ConsumoDeLamina.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDataContext _context;
        private readonly IConfiguration _configuration;
        public UserRepository(ApplicationDataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //private IMapper _mapper;
        public async Task<bool> ExistsUser(string email)
        {
            if (await _context.Users.AnyAsync(usr => usr.Email.Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));

            if (user == null)
            {
                return "nouser";
            }
            else if (!CheckPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return "wrongpassword";
            }
            else
            {
                return CreateToken(user);
            }
        }

        public async Task<int> Register(User user, string password)
        {
            try
            {
                if (await ExistsUser(user.Email))
                {
                    return -1;
                }

                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
            catch (Exception ex)
            {

                return -500;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool CheckPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDEscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDEscriptor);

            return tokenHandler.WriteToken(token);               
        }
    }
}
