using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AssignmentLukaLariashvili.Dal.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    void Remove(TEntity entity);

    Task<ICollection<TEntity>> GetAllAsync();

    Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);

    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
}

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AssignmentDbContext DataBaseContext;

    protected Repository(AssignmentDbContext context)
    {
        DataBaseContext = context;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await DataBaseContext.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await Task.Run(() =>
        {
            DataBaseContext.Set<TEntity>().Attach(entity);
            DataBaseContext.Entry(entity).State = EntityState.Modified;
        });
        return entity;
    }

    public void Remove(TEntity entity)
    {
        DataBaseContext.Set<TEntity>().Remove(entity);
    }

    public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
    {
        return await DataBaseContext.Set<TEntity>().FirstOrDefaultAsync(match);
    }
    public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
    {
        return await DataBaseContext.Set<TEntity>().Where(match).ToListAsync();
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await DataBaseContext.Set<TEntity>().ToListAsync();
    }
}
