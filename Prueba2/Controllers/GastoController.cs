using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba2;

namespace Prueba2.Controllers
{
    public class GastoController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: Gasto
        public ActionResult Index()
        {
            var gasto = db.Gasto.Include(g => g.Empleado);
            return View(gasto.ToList());
        }

        // GET: Gasto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasto gasto = db.Gasto.Find(id);
            if (gasto == null)
            {
                return HttpNotFound();
            }
            return View(gasto);
        }

        // GET: Gasto/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre");
            return View();
        }

        // POST: Gasto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_gasto,tipo_gasto,importe,id_empleado,factura")] Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                db.Gasto.Add(gasto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre", gasto.id_empleado);
            return View(gasto);
        }

        // GET: Gasto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasto gasto = db.Gasto.Find(id);
            if (gasto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre", gasto.id_empleado);
            return View(gasto);
        }

        // POST: Gasto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_gasto,tipo_gasto,importe,id_empleado,factura")] Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre", gasto.id_empleado);
            return View(gasto);
        }

        // GET: Gasto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasto gasto = db.Gasto.Find(id);
            if (gasto == null)
            {
                return HttpNotFound();
            }
            return View(gasto);
        }

        // POST: Gasto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gasto gasto = db.Gasto.Find(id);
            db.Gasto.Remove(gasto);
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
