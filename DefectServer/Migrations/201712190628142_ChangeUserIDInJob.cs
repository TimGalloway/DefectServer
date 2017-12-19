namespace DefectServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIDInJob : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "User_Id", "dbo.Users");
            DropIndex("dbo.Jobs", new[] { "User_Id" });
            RenameColumn(table: "dbo.Jobs", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Jobs", "UserId", c => c.Int(nullable: true));
            CreateIndex("dbo.Jobs", "UserId");
            AddForeignKey("dbo.Jobs", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "UserId", "dbo.Users");
            DropIndex("dbo.Jobs", new[] { "UserId" });
            AlterColumn("dbo.Jobs", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Jobs", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Jobs", "User_Id");
            AddForeignKey("dbo.Jobs", "User_Id", "dbo.Users", "Id");
        }
    }
}
