using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library.Models.Entity;
namespace library.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        LibraryEntities db = new LibraryEntities();
        public ActionResult Index()
        {
            var values = db.TBLUser.ToList();
            return View(values);
        }
        

        [HttpGet]
        public ActionResult AddUser()
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
        public ActionResult AddUser(TBLUser p)
        {
            db.TBLUser.Add(p);
            var loc = db.Libraries.Where(a => a.LibrariesID == p.Libraries.LibrariesID).FirstOrDefault();
            p.Libraries = loc;
            
          
          

            db.SaveChanges();
            return View("Index");
        }

        public ActionResult DeleteUser(int id)

        {
            var user = db.TBLUser.Find(id);
            db.TBLUser.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateUser(int id)

        {
            var update = db.TBLUser.Find(id);


            List<SelectListItem> values3 = (from i in db.Libraries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.LibraryName,
                                                Value = i.LibrariesID.ToString()
                                            }).ToList();
            ViewBag.value3 = values3;



            return View("UpdateUser", update);
        }
        public ActionResult SaveUser(TBLUser p)
        {
            var getir = db.TBLUser.Find(p.UserID);
            getir.UserName = p.UserName;
            getir.UserSurname = p.UserSurname;
            getir.UserMail = p.UserMail;
            getir.UserUsername = p.UserUsername;
            getir.UserPassword = p.UserPassword;
            getir.UserPicture = p.UserPicture;
            getir.UserPhone = p.UserPhone;
            getir.UserSchool = p.UserSchool;
            getir.UserDetail = p.UserDetail;
          

            var loc = db.Libraries.Where(b => b.LibrariesID == p.Libraries.LibrariesID).FirstOrDefault();
            getir.LibraryID = loc.LibrariesID;

            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
