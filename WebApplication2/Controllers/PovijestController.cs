using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.DB;

namespace WebApplication2.Controllers
{
    public class PovijestController : Controller
    {
        praEntities1 db = new praEntities1();
        public ActionResult Index()
        {
            var lista = (from d in db.Namirnices
                         join f in db.Meals on d.ObrokID equals
                         f.ID_Meals
                         join g in db.TipNamirnices on d.TipNamirnice_ID
                         equals g.ID_tipnamirnice

                         select d).ToList();
            return View(lista);
        }

        [HttpPost]
        public ActionResult Index(DateTime start, DateTime end)
        {
            return View(db.Povists(start, end));
        }
    }
}