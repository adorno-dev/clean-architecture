namespace CleanArchitecture.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task Commit(CancellationToken cancellationToken);        
    }
}