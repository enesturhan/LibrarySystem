using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library.Models.Entity;
namespace library.Controllers
{
    public class CategoryController : Controller
    {
        LibraryEntities db = new LibraryEntities();

        // GET: Category
        public ActionResult Index()
            /////////burada metodlar tamamlıyoruz view sayfasıyla ilişkilendirme yapıyoruz
        {
            var values = db.TBLCategory.ToList();
            
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddCategory(TBLCategory p)
        {
            db.TBLCategory.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteCategory(int id)

        {
            var Category = db.TBLCategory.Find(id);
            db.TBLCategory.Remove(Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateCategory(int id)

        {
            var update = db.TBLCategory.Find(id);
            return View("UpdateCategory", update);
        }
        public ActionResult SaveCategory(TBLCategory p)
        {
            var getir = db.TBLCategory.Find(p.CategoryID);
            getir.Name = p.Name;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}