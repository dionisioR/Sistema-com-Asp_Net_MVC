using SistemaLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLoja.ViewModels {
    public class OrdemView {
        public Customizar Customizar { get; set; }
        public List<ProdutoOrdem> ProdutoOrdem { get; set; }
    }
}