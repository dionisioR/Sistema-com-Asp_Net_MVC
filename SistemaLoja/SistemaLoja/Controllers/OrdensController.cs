using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLoja.ViewModels;
using SistemaLoja.Models;
using SistemaLoja.Data;

namespace SistemaLoja.Controllers
{
    public class OrdensController : Controller
    {
        private SistemaLojaContext db = new SistemaLojaContext();
        // GET: Ordens
        public ActionResult NovaOrdem()
        {
            var ordemView = new OrdemView();
            ordemView.Customizar = new Customizar();
            ordemView.ProdutoOrdem = new List<ProdutoOrdem>();

            var list = db.TipoDocumentoes.ToList();
            list.Add(new TipoDocumento { TipoDocumentoID = 0, Descricao = "[Selecione um tipo de documento!]" });
            list = list.OrderBy(c => c.Descricao).ToList();
            ViewBag.TipoDocumentoID = new SelectList(list, "TipoDocumentoID", "Descricao");

            return View(ordemView);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}