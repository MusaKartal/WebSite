using LavenderHome.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LavenderHome.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly ApplicationDbContext _context;
        

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task CreateAsync(TEntity entity)
        {

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
                  _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();  
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task UpdateAsync(int id,TEntity entity)
        {

            _context.Set<TEntity>().Update(entity);
              await _context.SaveChangesAsync(); 
        }

    }
}
