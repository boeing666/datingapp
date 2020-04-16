﻿using System.Threading.Tasks;
using Dating.App.Backend.Models;
using Dating.App.Backend.Models.ResponseModels;

namespace Dating.App.Backend.Interfaces.Repository
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
