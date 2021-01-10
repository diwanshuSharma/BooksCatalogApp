
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
    public class ReturnBooksController : Controller
    {
        IBookManager mgr = new BookManager();

        [AllowAnonymous]
        // GET: ReturnBooks
        public ActionResult Index()
        {
            var returnedBooks = mgr.GetAllReturnedBooks();
            return View(returnedBooks);
        }

        public ActionResult ReturnBook(int issueId)
        {
            mgr.AddReturnedBook(issueId);

            // not possible due to foreign key constraint
            //mgr.DeleteIssuedBook(issueId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var returnedBook = mgr.GetReturnedBookById(id);
            return View(returnedBook);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                mgr.DeleteReturnedBook(id.Value);
            }
            else
            {
                //not able to delete
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var returnedBook = mgr.GetReturnedBookById(id);
            return View(returnedBook);
        }

        [HttpPost]
        public ActionResult Edit(ReturnBook editReturnedBook)
        {
            mgr.EditReturnedBook(editReturnedBook);
            
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Search(string returnedBook)
        {
            if (returnedBook == null)
                return RedirectToAction("Index");

            var searchedReturnedBook = mgr.SearchByDateOfReturn(returnedBook);
            return View("Index", searchedReturnedBook);
        }
    }
}