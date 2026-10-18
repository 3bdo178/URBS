using URBS.Models;

namespace URBS.Repo.Abstraction
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<User> GetByEmail(string email);
    }
}
