using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagement.Models.Entity;

namespace MvcLibraryManagement.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.TblMove.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OnLoan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OnLoan(TblMove p)
        {
            db.TblMove.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult ReturnBookUpdate(TblMove p)
        {
            var move = db.TblMove.Find(p.ID);
            move.MemberReturnDate = p.MemberReturnDate;
            move.TransactionStatus = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}