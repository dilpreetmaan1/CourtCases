namespace CourtCases.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaseMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JudgeMastersID = c.Int(nullable: false),
                        PartiesID = c.Int(nullable: false),
                        LawyerMasterID = c.Int(nullable: false),
                        CaseName = c.String(),
                        Date = c.DateTime(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.JudgeMasters", t => t.JudgeMastersID, cascadeDelete: true)
                .ForeignKey("dbo.LawyerMasters", t => t.LawyerMasterID, cascadeDelete: true)
                .ForeignKey("dbo.Parties", t => t.PartiesID, cascadeDelete: true)
                .Index(t => t.JudgeMastersID)
                .Index(t => t.PartiesID)
                .Index(t => t.LawyerMasterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CaseMasters", "PartiesID", "dbo.Parties");
            DropForeignKey("dbo.CaseMasters", "LawyerMasterID", "dbo.LawyerMasters");
            DropForeignKey("dbo.CaseMasters", "JudgeMastersID", "dbo.JudgeMasters");
            DropIndex("dbo.CaseMasters", new[] { "LawyerMasterID" });
            DropIndex("dbo.CaseMasters", new[] { "PartiesID" });
            DropIndex("dbo.CaseMasters", new[] { "JudgeMastersID" });
            DropTable("dbo.CaseMasters");
        }
    }
}
