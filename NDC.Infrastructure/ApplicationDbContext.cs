
namespace NDC.Infrastructure
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using NDC.Infrastructure.Migrations;
    using NDC.Infrastructure.Models;
    using System.Data.Entity;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public static void Initializer()
        {
            // Set the database intializer which is run once during application start
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
            Database.CommandTimeout = 3600;
        }

        public DbSet<Person> People { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
