using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppAssignment.Models;

namespace WebAppAssignment.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users model)
        {
            using (var context = new AssignmentEntities())
            {
                bool isValid = context.User_tbl.Any(x => x.Email == model.Email && x.Password == model.Password);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "User");
                }
                ModelState.AddModelError("", "Invalid Email and Password");
                return View();
            }           
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}