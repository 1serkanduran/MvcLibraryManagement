using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagement.Models.Entity;

namespace MvcLibraryManagement.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.TblStaff.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult StaffAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StaffAdd(TblStaff p)
        {
            if (!ModelState.IsValid)
            {
                return View("StaffAdd");
            }
            db.TblStaff.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffDelete(int id)
        {
            var staff = db.TblStaff.Find(id);
            db.TblStaff.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffBring(int id)
        {
            var staff = db.TblStaff.Find(id);
            return View("StaffBring", staff);
        }
        public ActionResult StaffUpdate(TblStaff p)
        {
            var staff = db.TblStaff.Find(p.ID);
            staff.Staff = p.Staff;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}