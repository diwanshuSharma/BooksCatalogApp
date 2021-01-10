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
    public class IssueBooksController : Controller
    {
        IBookManager mgr = new BookManager();

        [AllowAnonymous]
        // GET: IssueBooks
        public ActionResult Index()
        {
            var IssuedBooks = mgr.GetAllIssuedBooks();
            return View(IssuedBooks);
        }

        public ActionResult IssueBook(int id)
        {
            mgr.AddIssuedBook(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var issuedBook = mgr.GetIssuedBookById(id);
            return View(issuedBook);
        }

        [HttpPost]
        public ActionResult Edit(IssueBook editIssuedBook)
        {
            mgr.EditIssuedBook(editIssuedBook);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var issuedBook = mgr.GetIssuedBookById(id);
            return View(issuedBook);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null) {
                mgr.DeleteIssuedBook(id.Value);
            }
            else
            {
                // not able to delete
            }

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Search(string issuedBook)
        {
            if (issuedBook == null)
                RedirectToAction("Index");

            var searchedIssuedBooks = mgr.SearchByMembershipNameOrDOI(issuedBook);
            return View("Index", searchedIssuedBooks);
        }
    }
}