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

			List<SelectListItem> item = (from i in db.TBLKATEGORILER.ToList()
										 select new SelectListItem
										 {
											 Text = i.KATEGORIAD,
											 Value = i.KATEGORIID.ToString()
										 }).ToList();
			ViewBag.dgr = item;
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(TBLURUNLER item)
		{
			var kategoriitem = db.TBLKATEGORILER.Where(m => m.KATEGORIID == item.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
			item.TBLKATEGORILER = kategoriitem;
			db.TBLURUNLER.Add(item);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		public ActionResult Sil(int id)
		{
			var findid = db.TBLURUNLER.Find(id);
			db.TBLURUNLER.Remove(findid);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

	}
}