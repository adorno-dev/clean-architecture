using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) {}

        public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
            => await context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}