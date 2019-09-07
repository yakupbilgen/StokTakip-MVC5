using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_StokTakip.Models.Entity;

namespace MVC5_StokTakip.Controllers
{
	public class KategoriController : Controller
	{
		DBStokTakipEntities db = new DBStokTakipEntities();
		// GET: Kategori
		public ActionResult Index()
		{
			var dbgetir = db.TBLKATEGORILER.ToList();
			return View(dbgetir);
		}

		public ActionResult Sil(int item)
		{
			var kategorisil = db.TBLKATEGORILER.Find(item);
			db.TBLKATEGORILER.Remove(kategorisil);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Guncelle(TBLKATEGORILER item)
		{
			var kategoriguncelle = db.TBLKATEGORILER.Add(item);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult YeniKategoriEkle(TBLKATEGORILER item)
		{
			db.TBLKATEGORILER.Add(item);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}