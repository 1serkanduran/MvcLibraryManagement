using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagement.Models.Entity;

namespace MvcLibraryManagement.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index(string p)
        {
            var books = from b in db.TblBook select b;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(x => x.Name.Contains(p));
            }
            //var books = db.TblBook.ToList();
            return View(books.ToList());
        }
        [HttpGet]
        public ActionResult BookAdd()
        {
            List<SelectListItem> deger1 = (from i in db.TblCategory.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Name,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TblWriter.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name +' '+ i.Surname,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult BookAdd(TblBook p)
        {
            var ctg = db.TblCategory.Where(c => c.ID == p.TblCategory.ID).FirstOrDefault();
            var wrt = db.TblWriter.Where(w => w.ID == p.TblWriter.ID).FirstOrDefault();
            p.TblCategory = ctg;
            p.TblWriter = wrt;
            db.TblBook.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookDelete(int id)
        {
            var book = db.TblBook.Find(id);
            db.TblBook.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookBring(int id)
        {
            var book = db.TblBook.Find(id);
            List<SelectListItem> deger1 = (from i in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TblWriter.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + ' ' + i.Surname,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("BookBring", book);
        }
        public ActionResult BookUpdate(TblBook p)
        {
            var book = db.TblBook.Find(p.ID);
            book.Name = p.Name;
            book.PritingYear = p.PritingYear;
            book.PagesNumber = p.PagesNumber;
            book.Publisher = p.Publisher;
            var ctg = db.TblCategory.Where(c => c.ID == p.TblCategory.ID).FirstOrDefault();
            var wrt = db.TblWriter.Where(w => w.ID == p.TblWriter.ID).FirstOrDefault();
            book.Category = ctg.ID;
            book.Writer = wrt.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}