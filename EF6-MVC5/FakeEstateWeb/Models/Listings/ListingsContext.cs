using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace FakeEstateWeb.Models.Listings
{
    public class ListingsContext : DbContext
    {
        public ListingsContext()
            : base("name=ListingsContext")
        {
        }

        public virtual DbSet<Listing> Listings { get; set; }
        public virtual DbSet<ListingPhoto> ListingPhotos { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Listing>()
                .HasRequired(l => l.SellingAgent)
                .WithMany(a => a.Listings)
                .HasForeignKey(a => a.SellingAgentId);

            modelBuilder.Entity<ListingPhoto>()
                .ToTable("ListingPhoto");
        }
    }
}
