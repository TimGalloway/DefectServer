namespace DefectServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReferenceToJobs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Reference", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Reference");
        }
    }
}
