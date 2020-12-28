namespace WebQuangTriKinhDoanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ffsfas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanPhams", "matHang_Id", "dbo.MatHangs");
            DropIndex("dbo.SanPhams", new[] { "matHang_Id" });
            AddColumn("dbo.SanPhams", "matHang_Id1", c => c.Guid());
            AlterColumn("dbo.SanPhams", "matHang_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.SanPhams", "matHang_Id1");
            AddForeignKey("dbo.SanPhams", "matHang_Id1", "dbo.MatHangs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "matHang_Id1", "dbo.MatHangs");
            DropIndex("dbo.SanPhams", new[] { "matHang_Id1" });
            AlterColumn("dbo.SanPhams", "matHang_Id", c => c.Guid());
            DropColumn("dbo.SanPhams", "matHang_Id1");
            CreateIndex("dbo.SanPhams", "matHang_Id");
            AddForeignKey("dbo.SanPhams", "matHang_Id", "dbo.MatHangs", "Id");
        }
    }
}
