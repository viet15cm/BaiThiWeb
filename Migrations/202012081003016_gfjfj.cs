namespace WebQuangTriKinhDoanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfjfj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanPhams", "matHang_Id1", "dbo.MatHangs");
            DropIndex("dbo.SanPhams", new[] { "matHang_Id1" });
            RenameColumn(table: "dbo.SanPhams", name: "matHang_Id1", newName: "MatHangId");
            AlterColumn("dbo.SanPhams", "MatHangId", c => c.Guid(nullable: false));
            CreateIndex("dbo.SanPhams", "MatHangId");
            AddForeignKey("dbo.SanPhams", "MatHangId", "dbo.MatHangs", "Id", cascadeDelete: true);
            DropColumn("dbo.SanPhams", "matHang_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SanPhams", "matHang_Id", c => c.Guid(nullable: false));
            DropForeignKey("dbo.SanPhams", "MatHangId", "dbo.MatHangs");
            DropIndex("dbo.SanPhams", new[] { "MatHangId" });
            AlterColumn("dbo.SanPhams", "MatHangId", c => c.Guid());
            RenameColumn(table: "dbo.SanPhams", name: "MatHangId", newName: "matHang_Id1");
            CreateIndex("dbo.SanPhams", "matHang_Id1");
            AddForeignKey("dbo.SanPhams", "matHang_Id1", "dbo.MatHangs", "Id");
        }
    }
}
