using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library.Models.Entity;
namespace library.Controllers
{
    public class MovementController : Controller
    {
        LibraryEntities db = new LibraryEntities();
        // GET: Movement
        public ActionResult Index()
        {
            var values = db.TBLAction.Where(x => x.ActionCase == true).ToList();


            return View(values);
        }
    }
}