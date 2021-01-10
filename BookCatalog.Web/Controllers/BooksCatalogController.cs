using BookCatalog.Business;
using BooksCatalog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalog.Web.Controllers
{
    [Authorize]
    public class BooksCatalogController : Controller
    {
        IBookManager mgr = new BookManager();
        
        
        [AllowAnonymous]
        // GET: BooksCatalog
        public ActionResult Index()
        {
            var books = mgr.GetAllBooks();
            return View(books);
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book addBook)
        {
            mgr.AddBook(addBook);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editBook = mgr.GetBookById(id);
            return View(editBook);
        }

        [HttpPost]
        public ActionResult Edit(Book editBook)
        {
            mgr.EditBook(editBook);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteBook = mgr.GetBookById(id);
            return View(deleteBook);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                mgr.DeleteBook(id.Value);
            }
            else
            {
                // unable to delete add Notification
            }

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Search(string book)
        {
            if(book == null)
            {
                return RedirectToAction("Index");
            }

            var searchedBooks = mgr.SearchByBookNameOrAuthor(book);
            return View("Index", searchedBooks);
        }
    }
}