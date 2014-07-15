namespace FakeEstateWeb.Migrations.Listings
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntroducePhotos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListingPhotoes",
                c => new
                    {
                        ListingPhotoId = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(),
                        Caption = c.String(),
                        ListingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListingPhotoId)
                .ForeignKey("dbo.Listings", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListingPhotoes", "ListingId", "dbo.Listings");
            DropIndex("dbo.ListingPhotoes", new[] { "ListingId" });
            DropTable("dbo.ListingPhotoes");
        }
    }
}
