using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JavniSite.Controllers
{
    public class PovistController : Controller
    {
        // GET: Povist
        praEntities10 db = new praEntities10();
        public ActionResult Index()
        {
            var lista = (from d in db.Namirnice
                         join f in db.Meals on d.ObrokID equals
                         f.ID_Meals
                         join g in db.TipNamirnice on d.TipNamirnice_ID
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