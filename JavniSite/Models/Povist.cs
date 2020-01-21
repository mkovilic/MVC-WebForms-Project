using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JavniSite.Models
{
    public class Povist
    {
        public string Meals { get; set; }
        public string Namirnica { get; set; }
        public string TipNamirnice { get; set; }
        public string MjernaJedinica { get; set; }
        [DataType(DataType.Password)]
        public string Datum{ get; set; }

        public List<Povist> userinfo { get; set; }

    }
}