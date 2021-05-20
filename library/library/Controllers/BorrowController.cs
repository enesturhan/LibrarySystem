using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library.Models.Entity;
namespace library.Controllers
{
    public class BorrowController : Controller
    {

        LibraryEntities db = new LibraryEntities();
        // GET: Borrow
        public ActionResult Index()
        {
            var values = db.TBLAction.Where(x => x.ActionCase == false).ToList();

            
            return View(values);
        }
       
        [HttpGet]
        public ActionResult Borrow()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Borrow(TBLAction p)
        {
            db.TBLAction.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Lending(int id)
        {
            var lend = db.TBLAction.Find(id);

            
            return View("Lending", lend);
        }

        public ActionResult UpdateLending(TBLAction p)

        {
            var update = db.TBLAction.Find(p.ActionID);

            update.userLendingTime = p.userLendingTime;
            update.ActionCase = true;
            db.SaveChanges();
          
            return View("Index");
        }
    }
}