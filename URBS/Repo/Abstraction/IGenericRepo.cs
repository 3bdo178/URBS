namespace URBS.Repo.Abstraction
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
