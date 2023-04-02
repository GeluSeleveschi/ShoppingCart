using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppinCart.DAL.Entities;

namespace ShoppinCart.DAL
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration) => _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("sqlConnection"));
        }

        public DbSet<Product> Products { get; set; }
    }
}
