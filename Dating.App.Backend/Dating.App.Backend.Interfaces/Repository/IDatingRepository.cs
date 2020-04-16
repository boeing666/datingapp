using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dating.App.Backend.Models;
using Dating.App.Backend.Models.ResponseModels;

namespace Dating.App.Backend.Interfaces.Repository
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}
