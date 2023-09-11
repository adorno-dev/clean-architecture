using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Persistence.Contexts;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Commit(CancellationToken cancellationToken)
            => await context.SaveChangesAsync(cancellationToken);
    }
}