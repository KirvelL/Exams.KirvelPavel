using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppOnion.WebApi.Data;
using WebAppOnion.WebApi.DTO;

namespace WebAppOnion.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        Random rnd = new Random();
        private readonly UsersRepository aa;

        public UsersController(UsersRepository aa)
        {
            this.aa = aa;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            aa.GetUsers();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "success";
        }

        // POST api/values
        [HttpPost]
        public UserResponseDto Post([FromBody] UserRequestDto user)
        {
            UserResponseDto userResponse = new UserResponseDto()
            {
                id = rnd.Next(0, 10000),
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            
            return userResponse;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public UserResponseDto Put(int id, [FromBody]UserRequestDto user)
        {
            UserResponseDto userResponse = new UserResponseDto()
            {
                id = rnd.Next(0, 10000),
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            return userResponse;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
