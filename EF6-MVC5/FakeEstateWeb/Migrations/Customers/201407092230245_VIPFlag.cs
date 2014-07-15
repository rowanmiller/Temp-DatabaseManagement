namespace FakeEstateWeb.Migrations.Customers
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VIPFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsVIP", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsVIP");
        }
    }
}
