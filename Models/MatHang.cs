using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebQuangTriKinhDoanh.Models
{
    public class MatHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Index(IsUnique = true)]
        [Required]
        [StringLength(450)]
        public string MatHangCode { get; set; }
        [Required]
        [MaxLength(30)]
        public string TenMH { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}