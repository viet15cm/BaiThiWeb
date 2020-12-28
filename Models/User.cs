using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebQuangTriKinhDoanh.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(450)]
        public string UserName { get; set; }
        [Required]
        [StringLength(30)]
        public string UserPassWord { get; set; }

        [Required]
        [StringLength(30)]
        public string UserRoler { get; set; }
        [Required]
        [StringLength(30)]
        public string UserEmail { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

    }
}