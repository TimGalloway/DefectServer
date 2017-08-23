namespace DefectServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Defects", "JobId", c => c.Int(nullable: false));
            CreateIndex("dbo.Defects", "JobId");
            AddForeignKey("dbo.Defects", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Defects", "JobId", "dbo.Jobs");
            DropIndex("dbo.Defects", new[] { "JobId" });
            DropColumn("dbo.Defects", "JobId");
            DropTable("dbo.Jobs");
        }
    }
}
