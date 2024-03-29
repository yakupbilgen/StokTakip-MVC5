﻿using System;
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
        public ActionResult Index(string searchitem)
        {
			var selectitem = from item in db.TBLMUSTERILER select item;
			if(!string.IsNullOrEmpty(searchitem))
			{
				selectitem = selectitem.Where(m => m.MUSTERIAD.Contains(searchitem));
			}

			return View(selectitem.ToList());
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