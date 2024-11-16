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
            ordemView.Produtos = new List<ProdutoOrdem>();
            Session["ordemView"] = ordemView;

            var list = db.Customizars.ToList();
            list.Add(new Customizar { CustomizarId = 0, Nome = "[Selecione um Cliente!]" });
            list = list.OrderBy(c => c.NomeCompleto).ToList();
            ViewBag.CustomizarId = new SelectList(list, "CustomizarId", "NomeCompleto");

            return View(ordemView);
        }

        [HttpPost]
        public ActionResult NovaOrdem(OrdemView ordemView) {

            ordemView = Session["ordemView"] as OrdemView;
            var customizarId = int.Parse(Request["CustomizarId"]);

            var list = db.Customizars.ToList();
            if (customizarId == 0) {
                list.Add(new Customizar { CustomizarId = 0, Nome = "[Selecione um cliente!]" });
                list = list.OrderBy(c => c.NomeCompleto).ToList();
                ViewBag.CustomizarId = new SelectList(list, "CustomizarId", "NomeCompleto");
                ViewBag.Error = "Selecione um Cliente";

                return View(ordemView);
            }

            var cliente = db.Customizars.Find(customizarId);

            if (cliente == null) {
                list.Add(new Customizar { CustomizarId = 0, Nome = "[Selecione um cliente!]" });
                list = list.OrderBy(c => c.NomeCompleto).ToList();
                ViewBag.CustomizarId = new SelectList(list, "CustomizarId", "NomeCompleto");
                ViewBag.Error = "O cliente não existe!";

                return View(ordemView);
            }
            
            if(ordemView.Produtos.Count == 0) {
                list.Add(new Customizar { CustomizarId = 0, Nome = "[Selecione um cliente!]" });
                list = list.OrderBy(c => c.NomeCompleto).ToList();
                ViewBag.CustomizarId = new SelectList(list, "CustomizarId", "NomeCompleto");
                ViewBag.Error = "Selecione um Produto";
                return View(ordemView);
            }
            var ordem = new Ordem {
                CustomizarId = customizarId,
                //************************
            };
            db.Ordem.Add(ordem);
            return View(ordemView);
        }


        public ActionResult AddProduto() {
            var ordemView = Session["ordemView"] as OrdemView;
            var list = db.Produtoes.ToList();
            list.Add(new ProdutoOrdem { ProdutoId = 0, Descricao = "[Selecione um produto!]" });
            list = list.OrderBy(c => c.Descricao).ToList();
            ViewBag.ProdutoId = new SelectList(list, "ProdutoId", "Descricao");

            return View(); 
        }

        [HttpPost]
        public ActionResult AddProduto(ProdutoOrdem produtoOrdem) {

            var ordemView = Session["ordemView"] as OrdemView;

            var list = db.Produtoes.ToList();
            var produtoId = int.Parse(Request["ProdutoId"]);
            if (produtoId == 0) {
                list.Add(new ProdutoOrdem { ProdutoId = 0, Descricao = "[Selecione um produto!]" });
                list = list.OrderBy(c => c.Descricao).ToList();
                ViewBag.ProdutoId = new SelectList(list, "ProdutoId", "Descricao");
                ViewBag.Error = "Selecione um Produto";

                return View(produtoOrdem);
            }

            var produto = db.Produtoes.Find(produtoId);

            if (produto == null) {
                list.Add(new ProdutoOrdem { ProdutoId = 0, Descricao = "[Selecione um produto!]" });
                list = list.OrderBy(c => c.Descricao).ToList();
                ViewBag.ProdutoId = new SelectList(list, "ProdutoId", "Descricao");
                ViewBag.Error = "Não existe o produto selecionado";

                return View(produtoOrdem);
            }

            produtoOrdem = ordemView.Produtos.Find(p => p.ProdutoId == produtoId);
            if (produtoOrdem == null) {

                produtoOrdem = new ProdutoOrdem {
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    ProdutoId = produtoId,
                    Quantidade = float.Parse(Request["Quantidade"])
                };

                ordemView.Produtos.Add(produtoOrdem);
            }
            else {
                produtoOrdem.Quantidade += float.Parse(Request["Quantidade"]); 
            }

            var listC = db.Customizars.ToList();
            listC.Add(new Customizar { CustomizarId = 0, Nome = "[Selecione um Cliente!]" });
            listC = listC.OrderBy(c => c.NomeCompleto).ToList();
            ViewBag.CustomizarId = new SelectList(listC, "CustomizarId", "NomeCompleto");


            return View("NovaOrdem", ordemView);
        }



        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}