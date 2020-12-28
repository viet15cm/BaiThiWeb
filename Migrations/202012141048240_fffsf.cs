namespace WebQuangTriKinhDoanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fffsf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 450),
                        UserPassWord = c.String(nullable: false, maxLength: 30),
                        UserRoler = c.String(nullable: false, maxLength: 30),
                        UserEmail = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserName" });
            DropTable("dbo.Users");
        }
    }
}
