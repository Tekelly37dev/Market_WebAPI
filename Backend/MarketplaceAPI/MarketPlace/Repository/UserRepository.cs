using System.Collections.Generic;
using MarketPlace.Models;
using MySql.Data.MySqlClient;
using System;

namespace MarketPlace.Repository{
    public class UserRepository:IUserRepository{
        private MySqlConnection _connection;
        public UserRepository()
        {
            string connectionString = "server=localhost;userid=root;password=TtJERK2025;database=mydb";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }
        ~UserRepository(){
            _connection.Close();
        }
        public IEnumerable<User> GetAllUsers(){
            var statement = "Select * from UserInfo";
            var command = new MySqlCommand(statement,_connection);
            var results = command.ExecuteReader();
            List<User> newList = new List<User>(1000);
            while (results.Read()){
                User m = new User {
                UserName=(string)results[0],
                FirstName=(string)results[1],
                LastName=(string)results[2],
                Email = (string)results[3],
                Password = (string)results[4],
                CreditCardInfo_CardNumber = (string)results[5]
                };
            newList.Add(m);
             }
            results.Close();
            return newList;
        }

        public User GetUserByUserName(string name){
             
             var statement = "Select * from UserInfo where UserName = @newUserName";
             var command = new MySqlCommand(statement,_connection); 
             command.Parameters.AddWithValue("@newUserName",name);
             var results = command.ExecuteReader();
             User m = null;
             if(results.Read()){
                  m = new User{
                UserName=(string)results[0],
                FirstName=(string)results[1],
                LastName=(string)results[2],
                Email = (string)results[3],
                Password = (string)results[4],
                CreditCardInfo_CardNumber = (string)results[5]
                };
             }
             results.Close();
             return m;
        }
        public void InsertUser(User m){
            var statement = "Insert into UserInfo (UserName, FirstName, LastName, Email, Password, CreditCardInfo_CardNumber) Values(@un,@f,@l,@e,@p,@c)";
            var command = new MySqlCommand(statement,_connection);
            command.Parameters.AddWithValue("@un",m.UserName);
            command.Parameters.AddWithValue("@f",m.FirstName);
            command.Parameters.AddWithValue("@l",m.LastName);
            command.Parameters.AddWithValue("@e",m.Email);
            command.Parameters.AddWithValue("@p",m.Password);
            command.Parameters.AddWithValue("@c",m.CreditCardInfo_CardNumber);
            int result = command.ExecuteNonQuery();
            Console.WriteLine(result);
        }
        public void UpdateUser(string name, User UserIn){
            var statement = "Update UserInfo Set UserName=@newUserName, FirstName=@newFirstName, LastName=@newLastName, Email=@newEmail, Password=@newPassword, CreditCardInfo_CardNumber=@newCreditCardInfo_CardNumber Where UserName=@updateUserName";   
            var command = new MySqlCommand(statement,_connection);
            command.Parameters.AddWithValue("@newUserName", UserIn.UserName);
            command.Parameters.AddWithValue("@newFirstName", UserIn.FirstName);
            command.Parameters.AddWithValue("@newLastName", UserIn.LastName);
            command.Parameters.AddWithValue("@@newEmail", UserIn.Email);
            command.Parameters.AddWithValue("@newPassword", UserIn.Password);
            command.Parameters.AddWithValue("@newCreditCardInfo_CardNumber", UserIn.CreditCardInfo_CardNumber);
            command.Parameters.AddWithValue("@updateUserName",name);
            int result = command.ExecuteNonQuery();
        }
        public void DeleteUser(string name){
            var statement = "DELETE FROM UserInfo  Where UserName=@deleteUserName";    
            var command = new MySqlCommand(statement,_connection);
            command.Parameters.AddWithValue("@deleteUserName",name);
            int result = command.ExecuteNonQuery();
        }
    }
}