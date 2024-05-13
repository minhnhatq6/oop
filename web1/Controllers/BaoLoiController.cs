using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web1.Controllers
{
    public class BaoLoiController : Controller
    {
        // GET: BaoLoi
        public ActionResult KhongCoQuyen()
        {
            return View();
        }
    }
}