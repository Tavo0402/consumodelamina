using ConsumoDeLamina.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoDeLamina.API.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<int> Register(User user, string password);
        Task<string> Login(string email, string password);
        Task<bool> ExistsUser(string email);
    }
}
