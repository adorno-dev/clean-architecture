using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Persistence.Extensions
{
    /// <summary>
    /// Connection string management for infrastructure project.
    /// 
    /// Use - User Secrets
    /// 
    /// {
    ///     "ConnectionStrings" : {
    ///         "<YourConnectionStringHere>
    ///     }    
    /// }
    /// 
    /// </summary>
    public static class ConnectionStrings
    {
        /// <summary>
        /// Gets connection string from user secret file.
        /// </summary>
        /// <typeparam name="TContextFactory">Type of context factory required.</typeparam>
        public static string? Get<TContextFactory>(string connectionString) where TContextFactory : class
            => new ConfigurationBuilder()
                  .AddUserSecrets<TContextFactory>()
                  .Build()
                  .GetConnectionString(connectionString);   
    }
}