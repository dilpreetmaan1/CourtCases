namespace CourtCases.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HearingMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CaseMasterID = c.Int(nullable: false),
                        CurrentDate = c.DateTime(),
                        NextDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CaseMasters", t => t.CaseMasterID, cascadeDelete: true)
                .Index(t => t.CaseMasterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HearingMasters", "CaseMasterID", "dbo.CaseMasters");
            DropIndex("dbo.HearingMasters", new[] { "CaseMasterID" });
            DropTable("dbo.HearingMasters");
        }
    }
}
