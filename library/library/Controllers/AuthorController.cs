using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library.Models.Entity;
namespace library.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        LibraryEntities db = new LibraryEntities();
        public ActionResult Index()
        /////////burada metodlar tamamlıyoruz view sayfasıyla ilişkilendirme yapıyoruz
        {
            var values = db.TblAuthor.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddAuthor(TblAuthor p)
        {
            db.TblAuthor.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult DeleteAuthor(int id)

        {
            var author = db.TblAuthor.Find(id);
            db.TblAuthor.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateAuthor(int id)

        {
            var update = db.TblAuthor.Find(id);
            return View("UpdateAuthor", update);
        }
        public ActionResult SaveAuthor(TblAuthor p)
        {
            var getir = db.TblAuthor.Find(p.authorID);
            getir.authorName = p.authorName;
            getir.authorSurname = p.authorSurname;
            getir.authorDetail = p.authorDetail;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}