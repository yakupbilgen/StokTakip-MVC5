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

		public ActionResult Sil(int id)
		{
			var findid = db.TBLMUSTERILER.Find(id);
			db.TBLMUSTERILER.Remove(findid);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Ekle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(TBLMUSTERILER item)
		{
			db.TBLMUSTERILER.Add(item);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		public ActionResult Guncelle(int id)
		{
			var musteriupdate = db.TBLMUSTERILER.Find(id);

			return View("Guncelle",musteriupdate);
		}

		public ActionResult Update(TBLMUSTERILER findid)
		{
			var update = db.TBLMUSTERILER.Find(findid.MUSTERIID);
			update.MUSTERIAD = findid.MUSTERIAD;
			update.MUSTERISOYAD = findid.MUSTERISOYAD;
			db.SaveChanges();

			return RedirectToAction("Index");
		}


    }
}