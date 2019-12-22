using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppOnion.WebApi.DTO;

namespace WebAppOnion.WebApi.Data
{
    public class OnionDbContext : DbContext
    {
        public OnionDbContext(DbContextOptions<OnionDbContext> options) : base(options)
        {

        }
        public DbSet<UserResponseDto> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
