using Microsoft.EntityFrameworkCore;
using URBS.Models;

namespace URBS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt):base (opt) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(u => u.Vehicle).WithOne(v => v.Driver).HasForeignKey<Vehicle>(v => v.DriverId);
            modelBuilder.Entity<User>().HasMany(u => u.RiderRides).WithOne(r => r.Rider).HasForeignKey(r => r.RiderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(u => u.DriverRides).WithOne(r => r.Driver).HasForeignKey(r => r.DriverId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ride>().HasOne(r => r.Rating).WithOne(R => R.Ride).HasForeignKey<Rating>(R => R.RideId);
            modelBuilder.Entity<Ride>().HasOne(r => r.Payment).WithOne(p => p.Ride).HasForeignKey<Payment>(p => p.RideId);
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
