using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;

namespace MarketPlace.Services{
    public class UserService:IUserServices{
        private IUserRepository _repo;
        public UserService(IUserRepository repo){
            _repo = repo;
        }
        public IEnumerable<User> GetUsers(){
            IEnumerable<User> myList = _repo.GetAllUsers();
            return myList;
        }
        public User GetUserByName(string name){
            return _repo.GetUserByUserName(name);       
        }  
        public void CreateUser(User m){
                _repo.InsertUser(m);
        }
        public void UpdateUser(string name, User m){
                _repo.UpdateUser(name ,m);
        }
        public void DeleteUser(string name){
                _repo.DeleteUser(name);
        }
    }
}