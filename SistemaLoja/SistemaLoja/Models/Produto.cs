using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models {
    public class Produto {
        [Key]
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime UltimaCompra { get; set; }
        public float Estoque { get; set; }
        public string Comentario { get; set; }
    }
}