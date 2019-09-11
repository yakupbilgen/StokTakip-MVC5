using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_StokTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC5_StokTakip.Controllers
{
	public class KategoriController : Controller
	{
		DBStokTakipEntities db = new DBStokTakipEntities();
		// GET: Kategori
		public ActionResult Index(int page=1)
		{
			//var readitem = db.TBLKATEGORILER.ToList();
			var readitem = db.TBLKATEGORILER.ToList().ToPagedList(page,5);

			return View(readitem);
		}

		public ActionResult Delete(int id)
		{
			var deleteitem = db.TBLKATEGORILER.Find(id);
			db.TBLKATEGORILER.Remove(deleteitem);
			db.SaveChanges();
			return RedirectToAction("Index");
		}


		public ActionResult Update(int id)
		{
			var updateitemm = db.TBLKATEGORILER.Find(id);

			return View("Update", updateitemm);
		}

		public ActionResult UpdateMethod(TBLKATEGORILER item)
		{
			var updateitem = db.TBLKATEGORILER.Find(item.KATEGORIID);
			updateitem.KATEGORIAD = item.KATEGORIAD;
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Ekle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(TBLKATEGORILER insertitem)
		{
			if(!ModelState.IsValid)
			{
				return View("Ekle");
			}
			db.TBLKATEGORILER.Add(insertitem);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}