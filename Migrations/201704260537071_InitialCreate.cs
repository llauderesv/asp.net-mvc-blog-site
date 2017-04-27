namespace BlogMoto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        blogId = c.Long(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        content = c.String(nullable: false, maxLength: 1000),
                        datePublish = c.DateTime(nullable: false),
                        url = c.String(nullable: false),
                        tags = c.String(),
                        author = c.String(),
                        createdBy = c.Long(nullable: false),
                        modifiedBy = c.Long(nullable: false),
                        dateCreated = c.DateTime(nullable: false),
                        dateModified = c.DateTime(nullable: false),
                        active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.blogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blogs");
        }
    }
}
