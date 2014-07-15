namespace FakeEstateWeb.Migrations.Listings
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListingStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listings", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listings", "Status");
        }
    }
}
