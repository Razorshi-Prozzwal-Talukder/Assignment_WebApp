using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppAssignment.Models;

namespace WebAppAssignment.Controllers
{
   [AllowAnonymous]
    public class HomeController : Controller
    {
        private AssignmentEntities db = new AssignmentEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "id,Name,Email,Phone")] Guest_tbl guest_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Guest_tbl.Add(guest_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest_tbl);
        }
    }
}
