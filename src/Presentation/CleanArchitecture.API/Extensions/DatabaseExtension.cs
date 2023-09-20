using CleanArchitecture.Persistence.Contexts;

namespace CleanArchitecture.API.Extensions
{
    public static class DatabaseExtension
    {
        public static void CreateDatabase(this WebApplication? app)
        {
            var serviceScope = app?.Services.CreateScope();
            var databaseContext = serviceScope?.ServiceProvider.GetService<AppDbContext>();
            databaseContext?.Database.EnsureCreated();
        }
    }
}