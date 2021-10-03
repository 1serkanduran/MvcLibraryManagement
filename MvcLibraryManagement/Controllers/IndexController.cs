using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagement.Models.Entity;
using MvcLibraryManagement.Models.Class;

namespace MvcLibraryManagement.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        DBLibraryEntities db = new DBLibraryEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.DGR1 = db.TblBook.ToList();
            cs.DGR2 = db.TblAbout.ToList();
            //var dgr = db.TblBook.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TblContact p)
        {
            db.TblContact.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}