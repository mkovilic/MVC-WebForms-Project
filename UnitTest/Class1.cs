using System;

namespace UnitTest
{
    public class Class1
    {


        //public string Name { get; set; }
        //public string Surname { get; set; }
        //public DateTime Dateofbirth { get; set; }
        //public int Visina { get; set; }
        //public int Tezina { get; set; }
        //public string Gender { get; set; }
        //public string Activity { get; set; }
        //public string Diabetes { get; set; }
        //public string Email { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //private int f_spol = 0;
        //private double f_aktivnost;
        //private double f_tip_dijabetesa;


        //public int CheckGender(int f_spol)
        //{
        //    if (Gender == "M")
        //    {
        //        this.f_spol += 5;
        //    }
        //    else if (Gender == "Z")
        //    {
        //        this.f_spol -= 161;
        //    }
        //    return f_spol;

        //}
        //public double CheckActivity(double f_aktivnost)
        //{
        //    if (Activity == "Niska")
        //    {
        //        this.f_aktivnost = 1.2;
        //    }
        //    else if (Activity == "Srednja")
        //    {
        //        this.f_aktivnost = 1.375;
        //    }
        //    else if (Activity == "Visoka")
        //    {
        //        this.f_aktivnost = 1.5;
        //    }
        //    return f_aktivnost;
        //}
        //public double CheckDiabetes(double f_tip_dijabetesa)
        //{
        //    if (Diabetes == "1")
        //    {

        //        this.f_tip_dijabetesa = 0.99;
        //    }
        //    else if (Diabetes == "2")
        //    {
        //        this.f_tip_dijabetesa = 0.98;
        //    }
        //    return f_tip_dijabetesa;
        //}

        //private double tezina = 0;
        //public double Weight(double tezina)
        //{
        //    this.tezina += (Tezina * 6.25);
        //    return tezina;
        //}
        //private int visina = 0;
        //public int Height(int visina)
        //{
        //    this.visina += (Visina * 10);
        //    return visina;
        //}

        //int age = 0;
        //public int Age(int age)
        //{

        //    DateTime now = DateTime.Today;
        //    this.age = now.Year - this.Dateofbirth.Year;
        //    if (this.Dateofbirth > now.AddYears(-age)) age--;
        //    return age;
        //}


        public double CalorieIntake(double tezina,double height, double age, double f_spol,double aktivnost,double f_tip_dijabetesa)
        {
            return (double)((tezina * 6.25) + (height * 10) - (5 * age) + (f_spol)) * (double) (aktivnost * f_tip_dijabetesa);
          
        }
        public double intake;
    }
}
