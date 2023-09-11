using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
    }
}