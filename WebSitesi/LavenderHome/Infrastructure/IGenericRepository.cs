using System.Collections.Generic;
using System.Threading.Tasks;

namespace LavenderHome.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id ,TEntity entity);

       

    }
}
