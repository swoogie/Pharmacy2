using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharmacy2.Models;

namespace Pharmacy2.Infra
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Drug> Drugs { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pharmacy2.Models.User> User { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
