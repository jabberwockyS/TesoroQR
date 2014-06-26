using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesoroQR.Models.Tesoro;

namespace TesoroQR.Controllers
{
    public class CircuitoController : Controller
    {
        private JuegoDBContext db = new JuegoDBContext();

        // GET: /Circuito/
        public ActionResult Index()
        {
            return View(db.Circuitos.ToList());
        }

        // GET: /Circuito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuito circuito = db.Circuitos.Find(id);
            if (circuito == null)
            {
                return HttpNotFound();
            }
            return View(circuito);
        }

        // GET: /Circuito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Circuito/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CircuitoID,Fecha,Nombre,Descripcion")] Circuito circuito)
        {
            if (ModelState.IsValid)
            {
                db.Circuitos.Add(circuito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(circuito);
        }

        // GET: /Circuito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuito circuito = db.Circuitos.Find(id);
            if (circuito == null)
            {
                return HttpNotFound();
            }
            return View(circuito);
        }

        // POST: /Circuito/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CircuitoID,Fecha,Nombre,Descripcion")] Circuito circuito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(circuito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(circuito);
        }

        // GET: /Circuito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuito circuito = db.Circuitos.Find(id);
            if (circuito == null)
            {
                return HttpNotFound();
            }
            return View(circuito);
        }

        // POST: /Circuito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Circuito circuito = db.Circuitos.Find(id);
            db.Circuitos.Remove(circuito);
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
