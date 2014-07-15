namespace FakeEstateWeb.Migrations.Listings
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        ListingId = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipOrPostalCode = c.String(),
                        Country = c.String(),
                        SellingAgentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListingId)
                .ForeignKey("dbo.Agents", t => t.SellingAgentId, cascadeDelete: true)
                .Index(t => t.SellingAgentId);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AgentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listings", "SellingAgentId", "dbo.Agents");
            DropIndex("dbo.Listings", new[] { "SellingAgentId" });
            DropTable("dbo.Agents");
            DropTable("dbo.Listings");
        }
    }
}
