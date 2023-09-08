using System;
using Microsoft.EntityFrameworkCore;
namespace T2207A_MVC.Entities
{
    public class DataContext : DbContext // quyet dinh ket noi db, truy van,...
    {
       
        public DataContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }
    }
}
