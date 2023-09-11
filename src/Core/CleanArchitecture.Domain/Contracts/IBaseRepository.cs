using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Contracts
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll(CancellationToken cancellationToken);
        Task<T?> Get(Guid id, CancellationToken cancellationToken);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}