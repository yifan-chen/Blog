namespace BlogRepository.MySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClickCountColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ClickCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "ClickCount");
        }
    }
}
