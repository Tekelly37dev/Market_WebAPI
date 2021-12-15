
using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;

namespace MarketPlace.Services{

    public interface IUserServices{
        public IEnumerable<User> GetUsers();
        public User GetUserByName(string name);
        public void CreateUser(User p);
        public void UpdateUser(string name, User p);
        public void DeleteUser(string name);
    }

}
