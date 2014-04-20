using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Kudogen.Model;

namespace Kudogen.DataAccess
{
    public class KudogenDbContext : DbContext
    {
        public KudogenDbContext()
            : base(nameOrConnectionString: "Kudogen") { }

        static KudogenDbContext()
        {
            Database.SetInitializer<KudogenDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Disable proxy creation and lazy loading; not wanted in this service context.
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            //modelBuilder.Configurations.Add(new SessionConfiguration());
            //modelBuilder.Configurations.Add(new AttendanceConfiguration());
        }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Nomination> Nominations { get; set; }
        public DbSet<Award> Awards { get; set; }
    }
}