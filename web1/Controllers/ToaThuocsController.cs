using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web1.Models;

namespace web1.Controllers
{
    public class ToaThuocsController : Controller
    {
        private QLPKTNEntities db = new QLPKTNEntities();

        // GET: ToaThuocs
        public ActionResult Index()
        {
            var toaThuocs = db.ToaThuocs.Include(t => t.BenhNhan);
            return View(toaThuocs.ToList());
        }

        // GET: ToaThuocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToaThuoc toaThuoc = db.ToaThuocs.Find(id);
            if (toaThuoc == null)
            {
                return HttpNotFound();
            }
            return View(toaThuoc);
        }

        // GET: ToaThuocs/Create
        public ActionResult Create()
        {
            ViewBag.MaBenhNhan = new SelectList(db.BenhNhans, "MaBenhNhan", "TenBenhNhan");
            return View();
        }

        // POST: ToaThuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,MaBenhNhan,BenhDuocChanDoan,NgayKham")] ToaThuoc toaThuoc)
        {
            if (ModelState.IsValid)
            {
                db.ToaThuocs.Add(toaThuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBenhNhan = new SelectList(db.BenhNhans, "MaBenhNhan", "TenBenhNhan", toaThuoc.MaBenhNhan);
            return View(toaThuoc);
        }

        // GET: ToaThuocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToaThuoc toaThuoc = db.ToaThuocs.Find(id);
            if (toaThuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBenhNhan = new SelectList(db.BenhNhans, "MaBenhNhan", "TenBenhNhan", toaThuoc.MaBenhNhan);
            return View(toaThuoc);
        }

        // POST: ToaThuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,MaBenhNhan,BenhDuocChanDoan,NgayKham")] ToaThuoc toaThuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toaThuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBenhNhan = new SelectList(db.BenhNhans, "MaBenhNhan", "TenBenhNhan", toaThuoc.MaBenhNhan);
            return View(toaThuoc);
        }

        // GET: ToaThuocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToaThuoc toaThuoc = db.ToaThuocs.Find(id);
            if (toaThuoc == null)
            {
                return HttpNotFound();
            }
            return View(toaThuoc);
        }

        // POST: ToaThuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToaThuoc toaThuoc = db.ToaThuocs.Find(id);
            db.ToaThuocs.Remove(toaThuoc);
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
