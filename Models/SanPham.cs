using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebQuangTriKinhDoanh.Models
{
    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(450)]
        public string SanPhamCode { get; set; }
        [Required]
        public string TenSP { get; set; }

        [Required]
        public decimal DonGia { get; set; }

        public string Anh { get; set; }
        public DateTime NgayCapNhat { get; set; }

        [ForeignKey("MatHangId")]
        public virtual MatHang matHang { get; set; }
        public Guid MatHangId { get; set; }


    }
}