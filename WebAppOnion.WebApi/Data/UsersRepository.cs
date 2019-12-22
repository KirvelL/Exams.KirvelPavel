using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppOnion.WebApi.Data;
using WebAppOnion.WebApi.DTO;

namespace WebAppOnion.WebApi
{
    public class UsersRepository
    {
        private readonly OnionDbContext db;
        public UsersRepository(OnionDbContext db)
        {
            this.db = db;
        }
        public IQueryable<UserResponseDto> GetUsers()
        {
            return db.Users.OrderBy(x => x.id);
        }

        public void SaveUser(UserResponseDto entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();

        }
        public UserResponseDto GetUserById(int id)
        {
            return db.Users.Single(x => x.id == id);
        }
        public UserResponseDto ChangeUser(UserResponseDto user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return user;
        }
        public void DeleteUser(List<UserResponseDto> entity)
        {
            foreach (var a in entity)
            {
                db.Users.Remove(a);
            }
            db.SaveChanges();
        }
        public void SaveListUser(List<UserResponseDto> entity)
        {
            foreach (var a in entity)
            {
                db.Users.Add(a);
            }
            db.SaveChanges();
        }
    }
}
