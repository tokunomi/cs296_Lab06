using TSTOneighboreenos.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TSTOneighboreenos.DAL
{
    public class NeighboreenoContext : DbContext
    {
        public NeighboreenoContext() : base("NeighboreenoContext")
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Neighbor> Neighbors { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}