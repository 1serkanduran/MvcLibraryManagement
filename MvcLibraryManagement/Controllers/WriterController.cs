using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagement.Models.Entity;

namespace MvcLibraryManagement.Controllers
{
    public class WriterController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Writer
        public ActionResult Index()
        {
            var deger = db.TblWriter.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterAdd(TblWriter p)
        {
            db.TblWriter.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult WriterDelete(int id)
        {
            var writer = db.TblWriter.Find(id);
            db.TblWriter.Remove(writer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult WriterBring(int id)
        {
            var writer = db.TblWriter.Find(id);
            return View("WriterBring", writer);
        }
        public ActionResult WriterUpdate(TblWriter p)
        {
            var writer = db.TblWriter.Find(p.ID);
            writer.Name = p.Name;
            writer.Surname = p.Surname;
            writer.Detail = p.Detail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}