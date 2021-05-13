using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagement.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcLibraryManagement.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index(int page=1)
        {
            //var degerler = db.TblMember.ToList();
            var degerler = db.TblMember.ToList().ToPagedList(page, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult MemberAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MemberAdd(TblMember p)
        {
            if (!ModelState.IsValid)
            {
                return View("MemberAdd");
            }
            db.TblMember.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemberDelete(int id)
        {
            var member = db.TblMember.Find(id);
            db.TblMember.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemberBring(int id)
        {
            var member = db.TblMember.Find(id);
            return View("MemberBring", member);
        }
        public ActionResult MemberUpdate(TblMember p)
        {
            var member = db.TblMember.Find(p.ID);
            member.Name = p.Name;
            member.Surname = p.Surname;
            member.Mail = p.Mail;
            member.Username = p.Username;
            member.Password = p.Password;
            member.PhotoURL = p.PhotoURL;
            member.Phone = p.Phone;
            member.School = p.School;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}