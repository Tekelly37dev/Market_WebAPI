using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarketPlace.Models;
using MarketPlace.Services;
using Microsoft.AspNetCore.Cors;

namespace MarketPlace.Controllers
{
    [ApiController]
    
    [Route("[controller]")]
    
    
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserServices _service;
        public UserController(ILogger<UserController> logger, IUserServices services)
        {
            _logger = logger;
            _service = services;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            IEnumerable<User> list = _service.GetUsers();
            if (list != null){
                     return Ok(list);
            }
            else 
            return NotFound();
                 
        }

         [HttpGet("{name}", Name = "GetUser")]
          public IActionResult GetUserByName(string name )
        {
           User obj =  _service.GetUserByName(name);
            if (obj != null)
                     return Ok(obj);

            return NotFound();

            }
            
       [EnableCors]
        [HttpPost]
        public IActionResult CreateUser(User m){
            
            _service.CreateUser(m);
            
            return CreatedAtRoute("GetUser", new {name=m.UserName}, m);

        }
           [HttpPut("{name}")] 
           public IActionResult UpdateUser(string name, User userIn){

                _service.UpdateUser(name,userIn);
                return NoContent();
            }
           
          [HttpDelete("{name}")] 
           public IActionResult DeleteUser(string name){

            _service.DeleteUser(name);
            return NoContent();    
           }           
    }
}

