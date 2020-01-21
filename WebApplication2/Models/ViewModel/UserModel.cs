using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModel
{
    public class UserModel
    {

        [Key]
        public int SYSUserID { get; set; }
        public int LOOKUPRoleID { get; set; }
        public string RoleName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login ID")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Dateofbirth { get; set; }
        [Range(120, 210)]
        [Display(Name = "Height")]
        public int Visina { get; set; }
        [Required]
        [Range(50, 300)]
        [Display(Name = "Weight")]
        public int Tezina { get; set; }
        [Required]
        public string Activity { get; set; }
        [Required]
        public string Diabetes { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        private int f_spol = 0;
        private double f_aktivnost;
        private double f_tip_dijabetesa;


        public int CheckGender(int f_spol)
        {
            if (Gender == "M")
            {
                this.f_spol += 5;
            }
            else if (Gender == "Z")
            {
                this.f_spol -= 161;
            }
            return f_spol;

        }
        public double CheckActivity(double f_aktivnost)
        {
            if (Activity == "Niska")
            {
                this.f_aktivnost = 1.2;
            }
            else if (Activity == "Srednja")
            {
                this.f_aktivnost = 1.375;
            }
            else if (Activity == "Visoka")
            {
                this.f_aktivnost = 1.5;
            }
            return f_aktivnost;
        }
        public double CheckDiabetes(double f_tip_dijabetesa)
        {
            if (Diabetes == "1")
            {

                this.f_tip_dijabetesa = 0.99;
            }
            else if (Diabetes == "2")
            {
                this.f_tip_dijabetesa = 0.98;
            }
            return f_tip_dijabetesa;
        }

        private double tezina = 0;
        public double Weight(double tezina)
        {
            this.tezina += (Tezina * 6.25);
            return tezina;
        }
        private int visina = 0;
        public int Height(int visina)
        {
            this.visina += (Visina * 10);
            return visina;
        }

        int age = 0;
        public int Age(int age)
        {

            DateTime now = DateTime.Today;
            this.age = now.Year - this.Dateofbirth.Year;
            if (this.Dateofbirth > now.AddYears(-age)) age--;
            return age;
        }


        public int CalorieIntake(int intake)
        {
            intake = (int)((Weight(tezina) + Height(visina) - (5 * Age(age)) + CheckGender(f_spol)) * CheckActivity(f_aktivnost) * CheckDiabetes(f_tip_dijabetesa));
            return intake;
        }
        public double intake;




    }
    public class UserLoginView
    {
        [Key]
        public int SYSUserID { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login ID")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class UserProfileView
    {
        [Key]
        public int SYSUserID { get; set; }
        public int LOOKUPRoleID { get; set; }
        public string RoleName { get; set; }
        public bool? IsRoleActive { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login ID")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Dateofbirth { get; set; }
        [Range(120, 210)]
        [Display(Name = "Height")]
        public int Visina { get; set; }
        [Required]
        [Range(50, 300)]
        [Display(Name = "Weight")]
        public int Tezina { get; set; }
        [Required]
        public string Activity { get; set; }
        [Required]
        public string Diabetes { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}