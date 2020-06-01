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
    public class ReunionController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: Reunion
        public ActionResult Index()
        {
            var reunion = db.Reunion.Include(r => r.Empleado);
            return View(reunion.ToList());
        }

        // GET: Reunion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reunion reunion = db.Reunion.Find(id);
            if (reunion == null)
            {
                return HttpNotFound();
            }
            return View(reunion);
        }

        // GET: Reunion/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre");
            return View();
        }

        // POST: Reunion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reunion,fecha,hora,direccion,id_empleado")] Reunion reunion)
        {
            if (ModelState.IsValid)
            {
                db.Reunion.Add(reunion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre", reunion.id_empleado);
            return View(reunion);
        }

        // GET: Reunion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reunion reunion = db.Reunion.Find(id);
            if (reunion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre", reunion.id_empleado);
            return View(reunion);
        }

        // POST: Reunion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reunion,fecha,hora,direccion,id_empleado")] Reunion reunion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reunion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre", reunion.id_empleado);
            return View(reunion);
        }

        // GET: Reunion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reunion reunion = db.Reunion.Find(id);
            if (reunion == null)
            {
                return HttpNotFound();
            }
            return View(reunion);
        }

        // POST: Reunion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reunion reunion = db.Reunion.Find(id);
            db.Reunion.Remove(reunion);
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
