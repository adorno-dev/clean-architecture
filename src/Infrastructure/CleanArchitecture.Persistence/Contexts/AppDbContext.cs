using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(ConnectionStrings.Get<AppDbContextFactory>("DefaultConnection"));

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users => Set<User>();
    }
}