using Microsoft.EntityFrameworkCore;
using URBS.Data;
using URBS.Models;
using URBS.Repo.Abstraction;

namespace URBS.Repo
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly AppDbContext context;

        public UserRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<User> GetByEmail(string email)
        {
            return context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
