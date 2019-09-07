using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_StokTakip.Models.Entity;

namespace MVC5_StokTakip.Controllers
{
    public class SatisController : Controller
    {
		DBStokTakipEntities db = new DBStokTakipEntities();

        // GET: Satis
        public ActionResult Index()
        {
			var dbgetir = db.TBLSATISLAR.ToList();
            return View(dbgetir);
        }
    }
}