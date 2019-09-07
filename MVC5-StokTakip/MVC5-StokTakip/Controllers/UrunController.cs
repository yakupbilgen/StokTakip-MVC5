using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_StokTakip.Models.Entity;

namespace MVC5_StokTakip.Controllers
{
    public class UrunController : Controller
    {
		DBStokTakipEntities db = new DBStokTakipEntities();

        // GET: Urun
        public ActionResult Index()
        {
			var dbgetir = db.TBLURUNLER.ToList();
			return View(dbgetir);
        }

		[HttpGet]
		public ActionResult Ekle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(TBLURUNLER item)
		{
			db.TBLURUNLER.Add(item);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

	}
}