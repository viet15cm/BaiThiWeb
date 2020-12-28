using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebQuangTriKinhDoanh.Models;

namespace WebQuangTriKinhDoanh.DBContext
{
    public class DBcontextLayer : DbContext
    {
        public DBcontextLayer() : base("name=WEB_BANG_HANG") 
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<MatHang> matHangs { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<SanPham>().Property(x => x.DonGia).HasPrecision(16, 2);
           

        }

       
    }
}