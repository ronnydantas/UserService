using Domain.Interfaces.Repositories;
using Infrascture.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrascture.Repositories;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly ClientContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(ClientContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entidade)
    {
        await _context.AddAsync(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entidade)
    {
        _context.Remove(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entidade)
    {
        _context.Update(entidade);
        await _context.SaveChangesAsync();
    }
}
