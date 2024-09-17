using System.Linq.Expressions;
using EasyEF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyEF.Repos;

public abstract class EasyEfRepositoryBase<TEntity>
    where TEntity : Entity
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _entitySet;

    protected EasyEfRepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext;
        _entitySet = _dbContext.Set<TEntity>();
    }

    /// <inheritdoc cref="DbContext"/>
    protected bool SaveChanges() => _dbContext.SaveChanges() >= 0;
    
    /// <inheritdoc cref="DbContext"/>
    protected async Task<bool> SaveChangesAsync() => await _dbContext.SaveChangesAsync() >= 0;

    /// <inheritdoc cref="DbContext"/>
    protected void Add(TEntity entity) => _entitySet.Add(entity);
    /// <inheritdoc cref="DbContext"/>
    protected async Task AddAsync(TEntity entity) => await _entitySet.AddAsync(entity);
    /// <inheritdoc cref="DbContext"/>
    protected void Add(params TEntity[] entities) => _entitySet.AddRange(entities);
    /// <inheritdoc cref="DbContext"/>
    protected async Task AddAsync(params TEntity[] entities) => await _entitySet.AddRangeAsync(entities);

    /// <inheritdoc cref="DbContext"/>
    protected void Update(TEntity entity) => _entitySet.Update(entity);
    /// <inheritdoc cref="DbContext"/>
    protected void UpdateAsync(params TEntity[] entities) => _entitySet.UpdateRange(entities);

    /// <inheritdoc cref="DbContext"/>
    protected void Delete(TEntity entity) => _entitySet.Remove(entity);
    /// <inheritdoc cref="DbContext"/>
    protected void Delete(params TEntity[] entities) => _entitySet.RemoveRange(entities);

    /// <inheritdoc cref="DbContext"/>
    protected TEntity? Get(Guid id) => _dbContext.Find<TEntity>(id);
    /// <inheritdoc cref="DbContext"/>
    protected async Task<TEntity?> GetAsync(Guid id) => await _dbContext.FindAsync<TEntity>(id);

    /// <inheritdoc cref="DbContext"/>
    protected bool Exists(Guid id) => Get(id) != null;
    /// <inheritdoc cref="DbContext"/>
    protected async Task<bool> ExistsAsync(Guid id) => await GetAsync(id) != null;

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? expr = null)
        => expr == null
            ? _entitySet.AsQueryable()
            : _entitySet.Where(expr);

    protected TEntity? Find(Guid id) => _entitySet.Find(id);
    protected async Task<TEntity?> FindAsync(Guid id) => await _entitySet.FindAsync(id);
    protected TEntity? GetById(Guid id) => Find(id);
    protected async Task<TEntity?> GetByIdAsync(Guid id) => await FindAsync(id);

    protected IAsyncEnumerable<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expr = null)
        => expr == null
            ? _entitySet.AsAsyncEnumerable()
            : _entitySet.Where(expr).AsAsyncEnumerable();

    /// <inheritdoc cref="DbContext"/>
    protected int Count(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? _entitySet.Count()
            : _entitySet.Count(expr);

    /// <inheritdoc cref="DbContext"/>
    protected async Task<int> CountAsync(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? await _entitySet.CountAsync()
            : await _entitySet.CountAsync(expr);

    /// <inheritdoc cref="DbContext"/>
    protected long LongCount(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? _entitySet.LongCount()
            : Get().LongCount(expr);


    /// <inheritdoc cref="DbContext"/>
    protected async Task<long> LongCountAsync(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? await _entitySet.LongCountAsync()
            : await Get().LongCountAsync(expr);

    /// <inheritdoc cref="DbContext"/>
    protected TEntity First(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? _entitySet.First()
            : _entitySet.First(expr);

    /// <inheritdoc cref="DbContext"/>
    protected async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? await _entitySet.FirstAsync()
            : await _entitySet.FirstAsync(expr);

    /// <inheritdoc cref="DbContext"/>
    protected TEntity? FirstOrDefault(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? _entitySet.FirstOrDefault()
            : _entitySet.FirstOrDefault(expr);

    /// <inheritdoc cref="DbContext"/>
    protected async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? await _entitySet.FirstOrDefaultAsync()
            : await _entitySet.FirstOrDefaultAsync(expr);

    /// <inheritdoc cref="DbContext"/>
    protected TEntity Single(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? _entitySet.Single()
            : _entitySet.Single(expr);
    /// <inheritdoc cref="DbContext"/>
    protected async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? await _entitySet.SingleAsync()
            : await _entitySet.SingleAsync(expr);

    /// <inheritdoc cref="DbContext"/>
    protected TEntity? SingleOrDefault(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? _entitySet.SingleOrDefault()
            : _entitySet.SingleOrDefault(expr);

    /// <inheritdoc cref="DbContext"/>
    protected async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? await _entitySet.SingleOrDefaultAsync()
            : await _entitySet.SingleOrDefaultAsync(expr);


    /// <inheritdoc cref="DbContext"/>
    protected TEntity Last(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? _entitySet.Last()
            : _entitySet.Last(expr);

    /// <inheritdoc cref="DbContext"/>
    protected async Task<TEntity> LastAsync(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? await _entitySet.LastAsync()
            : await _entitySet.LastAsync(expr);

    /// <inheritdoc cref="DbContext"/>
    protected TEntity? LastOrDefault(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? _entitySet.LastOrDefault()
            : _entitySet.LastOrDefault(expr);

    /// <inheritdoc cref="DbContext"/>
    protected async Task<TEntity?> LastOrDefaultAsync(Expression<Func<TEntity, bool>>? expr)
        => expr == null
            ? await _entitySet.LastOrDefaultAsync()
            : await _entitySet.LastOrDefaultAsync(expr);

    /// <inheritdoc cref="DbContext"/>
    protected TEntity? Min(Expression<Func<TEntity, TEntity>>? expr)
        => expr == null
            ? _entitySet.Min()
            : _entitySet.Min(expr);

    /// <inheritdoc cref="DbContext"/>
    protected async Task<TEntity?> MinAsync(Expression<Func<TEntity, TEntity>>? expr)
        => expr == null
            ? await _entitySet.MinAsync()
            : await _entitySet.MinAsync(expr);

    /// <inheritdoc cref="DbContext"/>
    protected TEntity? Max(Expression<Func<TEntity, TEntity>>? expr)
        => expr == null
            ? _entitySet.Max()
            : _entitySet.Max(expr);

    /// <inheritdoc cref="DbContext"/>
    protected async Task<TEntity?> MaxAsync(Expression<Func<TEntity, TEntity>>? expr)
        => expr == null
            ? await _entitySet.MaxAsync()
            : await _entitySet.MaxAsync(expr);

    /// <inheritdoc cref="DbContext"/>
    protected double Average(Expression<Func<TEntity, int>> expr)
        => _entitySet.Average(expr);
    /// <inheritdoc cref="DbContext"/>
    protected double Average(Expression<Func<TEntity, double>> expr)
        => _entitySet.Average(expr);
    /// <inheritdoc cref="DbContext"/>
    protected float Average(Expression<Func<TEntity, float>> expr)
        => _entitySet.Average(expr);
    /// <inheritdoc cref="DbContext"/>
    protected decimal Average(Expression<Func<TEntity, decimal>> expr)
        => _entitySet.Average(expr);
    /// <inheritdoc cref="DbContext"/>
    protected double Average(Expression<Func<TEntity, long>> expr)
        => _entitySet.Average(expr);

    /// <inheritdoc cref="DbContext"/>
    protected async Task<double> AverageAsync(Expression<Func<TEntity, int>> expr)
        => await _entitySet.AverageAsync(expr);
    /// <inheritdoc cref="DbContext"/>
    protected async Task<double> AverageAsync(Expression<Func<TEntity, double>> expr)
        => await _entitySet.AverageAsync(expr);
    /// <inheritdoc cref="DbContext"/>
    protected async Task<float> AverageAsync(Expression<Func<TEntity, float>> expr)
        => await _entitySet.AverageAsync(expr);
    /// <inheritdoc cref="DbContext"/>
    protected async Task<decimal> AverageAsync(Expression<Func<TEntity, decimal>> expr)
        => await _entitySet.AverageAsync(expr);
    /// <inheritdoc cref="DbContext"/>
    protected async Task<double> AverageAsync(Expression<Func<TEntity, long>> expr)
        => await _entitySet.AverageAsync(expr);

    /// <inheritdoc cref="DbContext"/>
    protected int Sum(Expression<Func<TEntity, int>> expr)
        => _entitySet.Sum(expr);
    /// <inheritdoc cref="DbContext"/>
    protected double Sum(Expression<Func<TEntity, double>> expr)
        => _entitySet.Sum(expr);
    /// <inheritdoc cref="DbContext"/>
    protected float Sum(Expression<Func<TEntity, float>> expr)
        => _entitySet.Sum(expr);
    /// <inheritdoc cref="DbContext"/>
    protected decimal Sum(Expression<Func<TEntity, decimal>> expr)
        => _entitySet.Sum(expr);
    /// <inheritdoc cref="DbContext"/>
    protected long Sum(Expression<Func<TEntity, long>> expr)
        => _entitySet.Sum(expr);

    /// <inheritdoc cref="DbContext"/>
    protected async Task<int> SumAsync(Expression<Func<TEntity, int>> expr)
        => await _entitySet.SumAsync(expr);
    /// <inheritdoc cref="DbContext"/>
    protected async Task<double> SumAsync(Expression<Func<TEntity, double>> expr)
        => await _entitySet.SumAsync(expr);
    /// <inheritdoc cref="DbContext"/>
    protected async Task<float> SumAsync(Expression<Func<TEntity, float>> expr)
        => await _entitySet.SumAsync(expr);
    /// <inheritdoc cref="DbContext"/>
    protected async Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> expr)
        => await _entitySet.SumAsync(expr);
    /// <inheritdoc cref="DbContext"/>
    protected async Task<long> SumAsync(Expression<Func<TEntity, long>> expr)
        => await _entitySet.SumAsync(expr);

}