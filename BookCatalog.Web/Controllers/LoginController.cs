using BookCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookCatalog.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HUser user, string ReturnUrl)
        {
            if (IsValid(user)) 
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return Redirect(ReturnUrl);
            }

            return View(user);
        }

        private bool IsValid(HUser user)
        {
            return user.Email != null && user.Email.Equals("admin@admin.com");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "BooksCatalog");
        }
    }
}