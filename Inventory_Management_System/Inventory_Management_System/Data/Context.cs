using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data
{
    public class Context:DbContext
    {
       
            Context(DbContextOptions<Context> options):base(options)
        {
        }
        public Context()
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=COM170-LAB3\\SQLEXPRESS;Initial Catalog=ProductManagement;Integrated Security=True;Trust Server Certificate=True");
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne<Supplier>(s => s.Supplier)
                .WithMany(p => p.Products)
                .HasForeignKey(s => s.SupplierID);
        }

    }
}
