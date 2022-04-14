using DNVImatisAssignment.Entities;
using DNVImatisAssignment.Infrastructures;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DNVImatisAssignment
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>().HasMany(s => s.Promotions).WithOne().HasForeignKey("IdPackage");
        } 
    }
}