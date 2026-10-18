using URBS.Data;
using URBS.Models;
using URBS.Repo.Abstraction;

namespace URBS.Unit_O__Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public IUserRepo Users { get; }

        public IGenericRepo<Payment> Payments { get; }

        public IGenericRepo<Rating> Ratings  { get; }

        public IGenericRepo<Ride> Rides { get; }

        public IGenericRepo<Vehicle> Vehicles { get; }
        public UnitOfWork(IUserRepo users, IGenericRepo<Payment> payments, IGenericRepo<Rating> ratings, IGenericRepo<Ride> rides, IGenericRepo<Vehicle> vehicles, AppDbContext context)
        {
            Users = users;
            Payments = payments;
            Ratings = ratings;
            Rides = rides;
            Vehicles = vehicles;
            this.context = context;
        }

        public Task<int> Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
