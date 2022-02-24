using ConsumoDeLamina.API.Repositories.IRepository;
using ConsumoDeLamina.Data;
using ConsumoDeLamina.Entities.DTOs;
using ConsumoDeLamina.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoDeLamina.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDataContext _context;

        public UserRepository(ApplicationDataContext context)
        {
            _context = context;
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

        public Task<string> Login(string email, string password)
        {
            throw new NotImplementedException();
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
    }
}
