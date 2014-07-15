namespace FakeEstateWeb.Migrations.Customers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class CustomersConfig : DbMigrationsConfiguration<FakeEstateWeb.Models.Customers.CustomerContext>
    {
        public CustomersConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Customers";
        }

        protected override void Seed(FakeEstateWeb.Models.Customers.CustomerContext context)
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
