using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PublicSite.Models.ViewModels;
using PublicSite.Models.DB;

namespace PublicSite.Models
{
    public class UserManager
    {
        private praEntities pra = new praEntities();

        public void Add(UserView user)
        {
            DB.Registracija sysUser = new DB.Registracija();
            sysUser.Ime = user.Name;
            sysUser.Prezime = user.Surname;
            sysUser.DatumRodenja = user.Dateofbirth.ToString();
            sysUser.Visina = user.Visina;
            sysUser.Tezina = user.Tezina;
            sysUser.Spol = user.Gender;
            sysUser.Aktivost = user.Activity;
            sysUser.Tip = user.Diabetes;
            sysUser.Email = user.Email;
            sysUser.Username = user.UserName;
            sysUser.Sifra = user.Password;


          //pra.AddToRegistracija(sysUser);
            pra.SaveChanges();
        }

        public bool IsUserLoginIDExist(string userLogIn)
        {
            return (from o in pra.Registracijas where o.Email == userLogIn select o).Any();
        }
    }
}