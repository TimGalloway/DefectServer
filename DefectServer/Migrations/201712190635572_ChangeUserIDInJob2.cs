namespace DefectServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIDInJob2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "UserId", "dbo.Users");
            DropIndex("dbo.Jobs", new[] { "UserId" });
            AlterColumn("dbo.Jobs", "UserId", c => c.Int());
            CreateIndex("dbo.Jobs", "UserId");
            AddForeignKey("dbo.Jobs", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "UserId", "dbo.Users");
            DropIndex("dbo.Jobs", new[] { "UserId" });
            AlterColumn("dbo.Jobs", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "UserId");
            AddForeignKey("dbo.Jobs", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
