using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_StokTakip.Models.Entity;

namespace MVC5_StokTakip.Controllers
{
    public class MusteriController : Controller
    {
		DBStokTakipEntities db = new DBStokTakipEntities();

        // GET: Musteri
        public ActionResult Index()
        {
			var dbgetir = db.TBLMUSTERILER.ToList();
            return View(dbgetir);
        }

		[HttpPost]
		public ActionResult YeniMusteriEkle(TBLMUSTERILER item)
		{
			db.TBLMUSTERILER.Add(item);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

    }
}