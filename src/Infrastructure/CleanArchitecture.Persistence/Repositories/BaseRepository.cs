using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
            => await context.Set<T>()
                            .ToListAsync(cancellationToken);

        public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
            => await context.Set<T>()
                            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public void Create(T entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow;
            context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DeletedAt = DateTimeOffset.UtcNow;
            context.Remove(entity);
        }
    }
}