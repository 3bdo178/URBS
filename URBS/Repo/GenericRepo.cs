using Microsoft.EntityFrameworkCore;
using URBS.Data;
using URBS.Repo.Abstraction;

namespace URBS.Repo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext context;

        public GenericRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task Add(T entity)
        {
           await context.Set<T>().AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public Task<List<T>> GetAll()
        {
            return context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await context.Set<T>().FindAsync(Id);
        }

        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
