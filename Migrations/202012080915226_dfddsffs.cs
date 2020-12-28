namespace WebQuangTriKinhDoanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfddsffs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MatHangs",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MatHangCode = c.String(nullable: false, maxLength: 450),
                        TenMH = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.MatHangCode, unique: true);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SanPhamCode = c.String(nullable: false, maxLength: 450),
                        TenSP = c.String(nullable: false),
                        DonGia = c.Decimal(nullable: false, precision: 16, scale: 2),
                        Anh = c.String(),
                        NgayCapNhat = c.DateTime(nullable: false),
                        matHang_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MatHangs", t => t.matHang_Id)
                .Index(t => t.SanPhamCode, unique: true)
                .Index(t => t.matHang_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "matHang_Id", "dbo.MatHangs");
            DropIndex("dbo.SanPhams", new[] { "matHang_Id" });
            DropIndex("dbo.SanPhams", new[] { "SanPhamCode" });
            DropIndex("dbo.MatHangs", new[] { "MatHangCode" });
            DropTable("dbo.SanPhams");
            DropTable("dbo.MatHangs");
        }
    }
}
