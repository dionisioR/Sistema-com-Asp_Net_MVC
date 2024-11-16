using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models {
    public class Produto {
        [Key]
        public int ProdutoId { get; set; }

        [Display(Name ="Descrição")]
        [Required(ErrorMessage ="Campor obrigatório")]
        public string Descricao { get; set; }

        [Display(Name ="Preço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]
        public decimal Preco { get; set; }

        [Display(Name ="Última compra")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =false)]
        // [DataType(DataType.Date)]
        public DateTime UltimaCompra { get; set; }

        [Display(Name ="Estoque")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString ="{0:N2}", ApplyFormatInEditMode =false)]
        public float Estoque { get; set; }

        [Display(Name = "Comentário")]
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }

        public virtual ICollection<FornecedorProduto> FornecedorProdutos { get; set; }
        public virtual ICollection<OrdemDetalhe> OrdemDetalhes { get; set; }
    }
}