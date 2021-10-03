using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryManagement.Models.Entity;

namespace MvcLibraryManagement.Controllers
{
    public class OperationController : Controller
    {
        // GET: Operation
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.TblMove.Where(x => x.TransactionStatus == true).ToList();
            return View(degerler);
        }
    }
}