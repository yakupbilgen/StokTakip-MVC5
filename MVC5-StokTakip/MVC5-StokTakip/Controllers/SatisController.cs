using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_StokTakip.Models.Entity;

//using PagedList;
//using PagedList.Mvc;

namespace MVC5_StokTakip.Controllers
{
    public class SatisController : Controller
    {
		DBStokTakipEntities db = new DBStokTakipEntities();

        // GET: Satis
        public ActionResult Index()
        {
			return View();
        }
		
		/*	Pageing işlemi için oluşturulan ActionResult
		public ActionResult Index(int page = 1)
		{
			var readitem = db.TBLSATISLAR.ToList().ToPagedList(page, 5);
			return View(readitem);
		}
		*/
		[HttpPost]
		public ActionResult Sales(TBLSATISLAR saleitem)
		{
			db.TBLSATISLAR.Add(saleitem);
			db.SaveChanges();

			return View("Index");
		}
    }
}