namespace BotPrototypeEmptyMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AwaitableTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TelegramAwaitables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AwaitableTag = c.String(),
                        Awaiting = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TelegramAwaitables");
        }
    }
}
