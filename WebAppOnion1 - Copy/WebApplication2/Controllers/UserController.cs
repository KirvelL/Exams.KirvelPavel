using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        UsersRepository fakeRepository = new UsersRepository();

        // GET api/values
        [Route("/users")]
        [HttpGet]
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            foreach (var a in fakeRepository.GetUsers())
            {
                users.Add(a);
            }
            return users;
        }


        [Route("/users/{name}")]
        [HttpPost]
        public string AddUser(string name)
        {
            fakeRepository.AddUser(name);
            return $"success  !";
        }

        [Route("/users/{userId}")]
        [HttpDelete]
        public string DeleteUser(Guid userId)
        {
            fakeRepository.DeleteUser(userId);
            return $"success  !";
        }
    }
}
