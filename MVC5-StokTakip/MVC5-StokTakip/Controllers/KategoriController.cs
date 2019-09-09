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

		public ActionResult Sil(int id)
		{
			var findid = db.TBLKATEGORILER.Find(id);
			db.TBLKATEGORILER.Remove(findid);
			db.SaveChanges();
			return RedirectToAction("Index");
		}


		public ActionResult Guncelle(int id)
		{
			var kategoriupdate = db.TBLKATEGORILER.Find(id);

			return View("Guncelle", kategoriupdate);
		}

		public ActionResult Update(TBLKATEGORILER findid)
		{
			var update = db.TBLKATEGORILER.Find(findid);
			update.KATEGORIAD = findid.KATEGORIAD;
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Ekle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(TBLKATEGORILER item)
		{
			db.TBLKATEGORILER.Add(item);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}