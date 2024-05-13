using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using web1.Models;

namespace web1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            else
            {


                return View();

            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]

        public ActionResult DangNhap(string user, string password)
        {
            QLPKTNEntities db = new QLPKTNEntities();
            var demtk = db.TaiKhoans.SingleOrDefault(m=>m.TenTk.ToLower()== user.ToLower()&& m.Mauk== password);
           
            if (demtk != null)
            {
                Session["user"] = "admin";
                
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "tai khoan hoac mat khau khong dung";
                return View();
            }
            
        }

        public ActionResult DangXuat()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap");
        }


    }
}