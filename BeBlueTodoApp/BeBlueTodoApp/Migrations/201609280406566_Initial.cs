namespace BeBlueTodoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TodoItems", "IsDone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoItems", "IsDone", c => c.Boolean(nullable: false));
        }
    }
}
