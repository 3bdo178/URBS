using URBS.Models;
using URBS.Repo.Abstraction;

namespace URBS.Unit_O__Work
{
    public interface IUnitOfWork
    {
        IUserRepo Users { get; }
        IGenericRepo<Payment> Payments { get; }
        IGenericRepo<Rating> Ratings { get; }
        IGenericRepo<Ride> Rides { get; }
        IGenericRepo<Vehicle> Vehicles { get; }
        Task<int> Save();
    }
}
