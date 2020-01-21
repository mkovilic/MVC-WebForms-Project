namespace JavniSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registracija")]
    public partial class Registracija
    {
        [StringLength(50)]
        public string Ime { get; set; }

        [StringLength(50)]
        public string Prezime { get; set; }

        [StringLength(10)]
        public string Spol { get; set; }

        [StringLength(10)]
        public string Tip { get; set; }

        [StringLength(10)]
        public string Aktivost { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Sifra { get; set; }

        public int? Kalorije { get; set; }

        public int? Tezina { get; set; }

        public int? Visina { get; set; }

        public DateTime? DatumRodenja { get; set; }

        [Key]
        public int ID_Registracija { get; set; }
    }
}
