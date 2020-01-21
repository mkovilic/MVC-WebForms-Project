using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicSite.Models.ViewModels
{
    public class UserView
    {
        [Required(ErrorMessage = "Please Enter Name e.g. Mate")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Name e.g. Kovilic")]
        [StringLength(30, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dateofbirth { get; set; }

        [Range(120, 210)]
        public int Visina { get; set; }

        [Required]
        [Range(50, 300)]
        public int Tezina { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Activity { get; set; }

        [Required]
        public string Diabetes { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Key]
        public int ID { get; set; }
    }
}