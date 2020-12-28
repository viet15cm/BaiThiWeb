using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebQuangTriKinhDoanh.Models.mvcModels
{
    public class mvcSanPham
    {
        
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [RegularExpression(@"^[A-Za-z0-9_\.]{5}$", ErrorMessage = "Mã là 5 kí tự thường không dấu")]
        public string SanPhamCode { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [StringLength(30, ErrorMessage =
             "TenSP should be less than or equal to ten characters.")]
        public string TenSP { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống ")]
        [Range(0, 100000000000, ErrorMessage =
              "Customer DonGia should be in 0 to 100000000000 range.")]
        public decimal DonGia { get; set; }

        public string Anh { get; set; }
        public DateTime NgayCapNhat {
            set
            {
            }

            get
            {
                return DateTime.Now;
            }
        }
        [Required(ErrorMessage = "Không Được Bỏ Trống")]
       
        public Guid MatHangId { get; set; }

        [NotMapped]

        public SelectList MatHangList { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }
        public mvcSanPham()
        {
            Anh = "~/AppFiles/Images/SanPham.png";
        }
    }
}