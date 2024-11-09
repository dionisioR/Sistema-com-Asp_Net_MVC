using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaLoja.Data;
using SistemaLoja.Models;

namespace SistemaLoja.Controllers
{
    public class CustomizarController : Controller
    {
        private SistemaLojaContext db = new SistemaLojaContext();

        // GET: Customizar
        public ActionResult Index()
        {
            var customizars = db.Customizars.Include(c => c.TipoDocumento);
            return View(customizars.ToList());
        }

        // GET: Customizar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customizar customizar = db.Customizars.Find(id);
            if (customizar == null)
            {
                return HttpNotFound();
            }
            return View(customizar);
        }

        // GET: Customizar/Create
        public ActionResult Create()
        {
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descricao");
            return View();
        }

        // POST: Customizar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomizarId,Nome,Telefone,Endereco,Email,Documento,TipoDocumentoID")] Customizar customizar)
        {
            if (ModelState.IsValid)
            {
                db.Customizars.Add(customizar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descricao", customizar.TipoDocumentoID);
            return View(customizar);
        }

        // GET: Customizar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customizar customizar = db.Customizars.Find(id);
            if (customizar == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descricao", customizar.TipoDocumentoID);
            return View(customizar);
        }

        // POST: Customizar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomizarId,Nome,Telefone,Endereco,Email,Documento,TipoDocumentoID")] Customizar customizar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customizar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descricao", customizar.TipoDocumentoID);
            return View(customizar);
        }

        // GET: Customizar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customizar customizar = db.Customizars.Find(id);
            if (customizar == null)
            {
                return HttpNotFound();
            }
            return View(customizar);
        }

        // POST: Customizar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customizar customizar = db.Customizars.Find(id);
            db.Customizars.Remove(customizar);
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
