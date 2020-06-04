using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAssignment.Models;

namespace WebAppAssignment.Controllers
{

    public class UserController : Controller
    {
        private AssignmentEntities db = new AssignmentEntities();
        // GET: User
        public ActionResult Index()
        {
            return View(db.Guest_tbl.ToList());
        }
    }
}