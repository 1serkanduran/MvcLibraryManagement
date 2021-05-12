using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagement.Models.Entity;

namespace MvcLibraryManagement.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.TblCategory.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(TblCategory p)
        {
            db.TblCategory.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var category = db.TblCategory.Find(id);
            db.TblCategory.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryBring(int id)
        {
            var category = db.TblCategory.Find(id);
            return View("CategoryBring", category);
        }
        public ActionResult CategoryUpdate(TblCategory p)
        {
            var category = db.TblCategory.Find(p.ID);
            category.Name = p.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}