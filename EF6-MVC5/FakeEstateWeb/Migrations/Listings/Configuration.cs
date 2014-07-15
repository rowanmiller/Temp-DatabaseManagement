namespace FakeEstateWeb.Migrations.Listings
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ListingsConfig : DbMigrationsConfiguration<FakeEstateWeb.Models.Listings.ListingsContext>
    {
        public ListingsConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Listings";
        }

        protected override void Seed(FakeEstateWeb.Models.Listings.ListingsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
