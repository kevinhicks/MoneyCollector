namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationwithRecieptTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reciepts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        WorldWideWork = c.Single(nullable: false),
                        Congregation = c.Single(nullable: false),
                        KingdomHallFund = c.Single(nullable: false),
                        Miscellaneous1 = c.Single(nullable: false),
                        Miscellaneous2 = c.Single(nullable: false),
                        Miscellaneous1Name = c.String(),
                        Miscellaneous2Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reciepts");
        }
    }
}
