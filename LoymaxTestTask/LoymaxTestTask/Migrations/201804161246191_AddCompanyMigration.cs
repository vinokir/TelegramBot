namespace LoymaxTestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "chatId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "chatId");
        }
    }
}
