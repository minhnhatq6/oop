using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web1.Models;

namespace web1.Controllers
{
    public class ThuocsController : Controller
    {
        private QLPKTNEntities db = new QLPKTNEntities();

        // GET: Thuocs
        public ActionResult Index(string search, string nuocsx)
        {
            var nuocsxLst = new List<string>();

            var nuocsxQry = from d in db.Thuocs
                            orderby d.NuocSx
                            select d.NuocSx;

            nuocsxLst.AddRange(nuocsxQry.Distinct());
            ViewBag.nuocsx = new SelectList(nuocsxLst);
            var thuocs = db.Thuocs.Include(t => t.ChiTietToaThuocs);
            var tenthuoc = from m in db.Thuocs
                              select m;
            if (!string.IsNullOrEmpty(search))
            {
                tenthuoc = tenthuoc.Where(s => s.TenThuoc.Contains(search));
                return View(tenthuoc);
            }
            if(!string.IsNullOrEmpty(nuocsx))
            {
                tenthuoc = tenthuoc.Where(x => x.NuocSx == nuocsx);
                return View(tenthuoc);
            }
            return View(thuocs.ToList());
        }

        // GET: Thuocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // GET: Thuocs/Create
        public ActionResult Create()
        {
            ViewBag.MaThuoc = new SelectList(db.ChiTietToaThuocs, "MaThuoc", "SoLuong");
            return View();
        }

        // POST: Thuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThuoc,TenThuoc,NuocSx,DonGia,HanSuDung,GhiChu,HinhAnh")] Thuoc thuoc)
        {

            if (ModelState.IsValid)
            {
                db.Thuocs.Add(thuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            

            ViewBag.MaThuoc = new SelectList(db.ChiTietToaThuocs, "MaThuoc", "SoLuong", thuoc.MaThuoc);
            return View(thuoc);
        }

        // GET: Thuocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaThuoc = new SelectList(db.ChiTietToaThuocs, "MaThuoc", "SoLuong", thuoc.MaThuoc);
            return View(thuoc);
        }

        // POST: Thuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThuoc,TenThuoc,NuocSx,DonGia,HanSuDung,GhiChu,HinhAnh")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaThuoc = new SelectList(db.ChiTietToaThuocs, "MaThuoc", "SoLuong", thuoc.MaThuoc);
            return View(thuoc);
        }

        // GET: Thuocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // POST: Thuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Thuoc thuoc = db.Thuocs.Find(id);
            db.Thuocs.Remove(thuoc);
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
