using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQuangTriKinhDoanh.Models.mvcModels
{
    public class mvcUser
    {
        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        public string PassWord { get; set; }
        public string grant_type
        {

            set
            {
            }

            get
            {
                return "password";
            }

        }

        public bool Remember { get; set; }
    }
}