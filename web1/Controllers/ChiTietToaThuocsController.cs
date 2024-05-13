using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web1.Models;
using System.Threading.Tasks;


namespace web1.Controllers
{
    public class ChiTietToaThuocsController : Controller
    {
        private QLPKTNEntities db = new QLPKTNEntities();

        // GET: ChiTietToaThuocs
        public ActionResult Index()
        {
            var chiTietToaThuocs = db.ChiTietToaThuocs.Include(c => c.Thuoc).Include(c => c.ToaThuoc);
            return View(chiTietToaThuocs.ToList());
        }

        // GET: ChiTietToaThuocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietToaThuoc chiTietToaThuoc = db.ChiTietToaThuocs.Find(id);
            if (chiTietToaThuoc == null)
            {
                return HttpNotFound();
            }
            return View(chiTietToaThuoc);
        }

        // GET: ChiTietToaThuocs/Create
        public ActionResult Create()
        {
            ViewBag.MaThuoc = new SelectList(db.Thuocs, "MaThuoc", "TenThuoc");
            ViewBag.STT = new SelectList(db.ToaThuocs, "STT", "MaBenhNhan");
            return View();
        }

        // POST: ChiTietToaThuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,MaThuoc,SoLuong,LieuDung,GhiChu")] ChiTietToaThuoc chiTietToaThuoc)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietToaThuocs.Add(chiTietToaThuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaThuoc = new SelectList(db.Thuocs, "MaThuoc", "TenThuoc", chiTietToaThuoc.MaThuoc);
            ViewBag.STT = new SelectList(db.ToaThuocs, "STT", "MaBenhNhan", chiTietToaThuoc.STT);
            return View(chiTietToaThuoc);
        }

        // GET: ChiTietToaThuocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietToaThuoc chiTietToaThuoc = db.ChiTietToaThuocs.Find(id);
            if (chiTietToaThuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaThuoc = new SelectList(db.Thuocs, "MaThuoc", "TenThuoc", chiTietToaThuoc.MaThuoc);
            ViewBag.STT = new SelectList(db.ToaThuocs, "STT", "MaBenhNhan", chiTietToaThuoc.STT);
            return View(chiTietToaThuoc);
        }

        // POST: ChiTietToaThuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,MaThuoc,SoLuong,LieuDung,GhiChu")] ChiTietToaThuoc chiTietToaThuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietToaThuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaThuoc = new SelectList(db.Thuocs, "MaThuoc", "TenThuoc", chiTietToaThuoc.MaThuoc);
            ViewBag.STT = new SelectList(db.ToaThuocs, "STT", "MaBenhNhan", chiTietToaThuoc.STT);
            return View(chiTietToaThuoc);
        }

        // GET: ChiTietToaThuocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietToaThuoc chiTietToaThuoc = db.ChiTietToaThuocs.Find(id);
            if (chiTietToaThuoc == null)
            {
                return HttpNotFound();
            }
            return View(chiTietToaThuoc);
        }

        // POST: ChiTietToaThuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            ChiTietToaThuoc chiTietToaThuoc = db.ChiTietToaThuocs.Find(id);
            db.ChiTietToaThuocs.Remove(chiTietToaThuoc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
