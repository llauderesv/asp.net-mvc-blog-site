namespace BlogMoto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "dateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "dateModified", c => c.DateTime(nullable: false));
        }
    }
}
