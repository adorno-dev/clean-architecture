using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Persistence.Contexts;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence.Extensions
{
    public static class PersistenceResources
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = ConnectionStrings.Get<AppDbContextFactory>("DefaultConnection");

            services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}