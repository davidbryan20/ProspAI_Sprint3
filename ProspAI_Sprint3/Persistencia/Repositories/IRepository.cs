namespace ProspAI_Sprint3.Persistencia.Repositories
{
    // Repositories/IRepository.cs
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace challenge_sprint2.Repositories
    {
        public interface IRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task AddAsync(T entity);
            Task UpdateAsync(T entity);
            Task DeleteAsync(int id);
        }
    }
}
