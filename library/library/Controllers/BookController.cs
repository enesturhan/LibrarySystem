using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library.Models.Entity;


namespace library.Controllers
{
    public class BookController : Controller
    {
        LibraryEntities db = new LibraryEntities();

        // GET: Kitap
        public ActionResult Index(string p)
        {
            var books = from k in db.TBLBook select k;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(b => b.bookName.Contains(p));

            }
          /////  var books = db.TBLBook.ToList();
            return View(books.ToList());
        }
        [HttpGet]
        public ActionResult AddBook()
        {

            List<SelectListItem> values = (from i in db.TBLCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.CategoryID.ToString()
                                           }).ToList();

            ViewBag.value = values;

            List<SelectListItem> values2 = (from i in db.TblAuthor.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.authorName + ' '+i.authorSurname,
                                                Value = i.authorID.ToString()
                                            }).ToList();
            ViewBag.value2 = values2;


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
        public ActionResult AddBook(TBLBook p)
        {
            var book = db.TBLCategory.Where(k => k.CategoryID == p.TBLCategory.CategoryID).FirstOrDefault();
            var aut = db.TblAuthor.Where(a => a.authorID == p.TblAuthor.authorID).FirstOrDefault();
            var loc = db.Libraries.Where(a => a.LibrariesID == p.Libraries.LibrariesID).FirstOrDefault();
            p.TBLCategory = book;
            p.TblAuthor = aut;
            p.Libraries = loc;
            db.TBLBook.Add(p);
           

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)

        {
            var book = db.TBLBook.Find(id);
            db.TBLBook.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateBook(int id)

        {
            var update = db.TBLBook.Find(id);
          
            List<SelectListItem> values = (from i in db.TBLCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.CategoryID.ToString()
                                           }).ToList();
            ViewBag.value = values;
            List<SelectListItem> values2 = (from i in db.TblAuthor.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.authorName + ' ' + i.authorSurname,
                                               Value = i.authorID.ToString()
                                           }).ToList();
            ViewBag.value2 = values2;


            List<SelectListItem> values3 = (from i in db.Libraries.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.LibraryName,
                                               Value = i.LibrariesID.ToString()
                                           }).ToList();
            ViewBag.value3 = values3;
            return View("UpdateBook", update);
        }
        public ActionResult SaveBook(TBLBook p)
        {
            var book = db.TBLBook.Find(p.bookID);
            book.bookName = p.bookName;
            book.bookYear = p.bookYear;
            book.bookPublisher = p.bookPublisher;
            book.bookPage = p.bookPage;
            book.bookCase = p.bookCase;
            var bk = db.TBLCategory.Where(b => b.CategoryID == p.TBLCategory.CategoryID).FirstOrDefault();
            var aut = db.TblAuthor.Where(b => b.authorID == p.TblAuthor.authorID).FirstOrDefault();
            var loc = db.Libraries.Where(b => b.LibrariesID == p.Libraries.LibrariesID).FirstOrDefault();
            book.bookCategory = bk.CategoryID;
            book.bookAuthor = aut.authorID;
            book.LibraryID = loc.LibrariesID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}