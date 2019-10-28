using IsmaelsRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsmaelsRestaurant.Persistence
{
    public class IsmaelsRestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Plate> Plates { get; set; }

        public IsmaelsRestaurantDbContext(DbContextOptions<IsmaelsRestaurantDbContext> options): base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasKey(key => key.Id);
            modelBuilder.Entity<Plate>().HasKey(key => key.Id);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}