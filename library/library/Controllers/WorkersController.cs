using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library.Models.Entity;
namespace library.Controllers
{
    public class WorkersController : Controller
    {
        LibraryEntities db = new LibraryEntities();
        // GET: Workers
        public ActionResult Index()
        {
            var values = db.TBLWorker.ToList();

            return View(values);
        }


        [HttpGet]
        public ActionResult AddWorker()
        {

            List<SelectListItem> values3 = (from i in db.Libraries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.LibraryName,
                                                Value = i.LibrariesID.ToString()
                                            }).ToList();
            ViewBag.value3 = values3;


            return View();

        }
        [HttpPost]
        public ActionResult AddWorker(TBLWorker p)
        {
            db.TBLWorker.Add(p);
            var loc = db.Libraries.Where(a => a.LibrariesID == p.Libraries.LibrariesID).FirstOrDefault();
            p.Libraries = loc;
            


            db.SaveChanges();
            return View("Index");
        }
        public ActionResult DeleteWorker(int id)

        {
            var work = db.TBLWorker.Find(id);
            db.TBLWorker.Remove(work);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateWorker(int id)

        {
            var update = db.TBLWorker.Find(id);


            List<SelectListItem> values3 = (from i in db.Libraries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.LibraryName,
                                                Value = i.LibrariesID.ToString()
                                            }).ToList();
            ViewBag.value3 = values3;



            return View("UpdateWorker", update);
        }
        public ActionResult SaveWorker(TBLWorker p)
        {
            var getir = db.TBLWorker.Find(p.WorkerID);
            getir.WorkerNameSurname = p.WorkerNameSurname;
            getir.WorkerDetail = p.WorkerDetail;

            var loc = db.Libraries.Where(b => b.LibrariesID == p.Libraries.LibrariesID).FirstOrDefault();
            getir.LibraryID = loc.LibrariesID;
            
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
    
