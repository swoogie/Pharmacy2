using Microsoft.EntityFrameworkCore;
using Pharmacy2.Models;

namespace Pharmacy2.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Drug> Drugs { get; set; } 
        public DbSet<Category> Categories { get; set; }
        

    }
}
