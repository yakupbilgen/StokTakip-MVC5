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
    public class MusteriController : Controller
    {
		DBStokTakipEntities db = new DBStokTakipEntities();

        // GET: Musteri
        public ActionResult Index(int page=1)
        {
			var readitem = db.TBLMUSTERILER.ToList().ToPagedList(page, 5);
            return View(readitem);
        }

		public ActionResult Delete(int id)
		{
			var deleteitem = db.TBLMUSTERILER.Find(id);
			db.TBLMUSTERILER.Remove(deleteitem);
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
			if(!ModelState.IsValid)
			{
				return View("Ekle");
			}
			db.TBLMUSTERILER.Add(item);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		public ActionResult Update(int id)
		{
			var updateitemm = db.TBLMUSTERILER.Find(id);

			return View("Update",updateitemm);
		}

		public ActionResult UpdateMethod(TBLMUSTERILER item)
		{
			var updateitem = db.TBLMUSTERILER.Find(item.MUSTERIID);
			updateitem.MUSTERIAD = item.MUSTERIAD;
			updateitem.MUSTERISOYAD = item.MUSTERISOYAD;
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		//public ActionResult UpdateMethod(TBLMUSTERILER p1)
		//{
		//	var musteri = db.TBLMUSTERILER.Find(p1.MUSTERIID);
		//	musteri.MUSTERIAD = p1.MUSTERIAD;
		//	musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
		//	db.SaveChanges();

		//	return RedirectToAction("Index");
		//}
    }
}