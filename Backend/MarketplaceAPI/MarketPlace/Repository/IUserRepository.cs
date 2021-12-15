using System.Collections.Generic;
using MarketPlace.Models;

namespace MarketPlace.Repository{
    public interface IUserRepository{
        public IEnumerable<User> GetAllUsers();
        public User GetUserByUserName(string name);
        public void InsertUser(User p );
        public void UpdateUser(string name, User p);
        public void DeleteUser(string name);
    }

}