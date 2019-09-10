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
    public class UrunController : Controller
    {
		DBStokTakipEntities db = new DBStokTakipEntities();

        // GET: Urun
        public ActionResult Index(int page=1)
        {
			var readitem = db.TBLURUNLER.ToList().ToPagedList(page, 5);
			return View(readitem);
        }

		[HttpGet]
		public ActionResult Ekle()
		{

			List<SelectListItem> item = (from tableitem in db.TBLKATEGORILER.ToList()
										 select new SelectListItem
										 {
											 Text = tableitem.KATEGORIAD,
											 Value = tableitem.KATEGORIID.ToString()
										 }).ToList();
			ViewBag.dgr = item;
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(TBLURUNLER item)
		{
			var insertitem = db.TBLKATEGORILER.Where(m => m.KATEGORIID == item.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
			item.TBLKATEGORILER = insertitem;
			db.TBLURUNLER.Add(item);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var deleteitem = db.TBLURUNLER.Find(id);
			db.TBLURUNLER.Remove(deleteitem);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		public ActionResult Update(int id)
		{
			var updateitemm = db.TBLURUNLER.Find(id);
			List<SelectListItem> item = (from tableitem in db.TBLKATEGORILER.ToList()
										 select new SelectListItem
										 {
											 Text = tableitem.KATEGORIAD,
											 Value = tableitem.KATEGORIID.ToString()
										 }).ToList();
			ViewBag.dgr = item;
			return View("Update",updateitemm);
		}

		public ActionResult UpdateMethod(TBLURUNLER item)
		{
			var updateitem = db.TBLURUNLER.Find(item.URUNID);
			updateitem.URUNAD = item.URUNAD;
			updateitem.URUNMARKA = item.URUNMARKA;

			//updateitem.URUNKATEGORI = item.URUNKATEGORI;
			var kategori = db.TBLKATEGORILER.Where(m => m.KATEGORIID == item.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
			updateitem.URUNKATEGORI= kategori.KATEGORIID;

			updateitem.URUNFIYAT = item.URUNFIYAT;
			updateitem.URUNSTOKADET = item.URUNSTOKADET;
			db.SaveChanges();

			return RedirectToAction("Index");
		}

	}
}