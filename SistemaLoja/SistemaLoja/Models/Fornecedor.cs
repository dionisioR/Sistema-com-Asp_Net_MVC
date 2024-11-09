using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models {
    public class Fornecedor {
        [Key]
        public int FornecedorId { get; set; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage = "Campor obrigatório")]
        public string Nome { get; set; }

        [Display(Name ="Telefone")]
        public string Telefone { get; set; }

        [Display(Name ="Endereço")] 
        public string Endereco { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Representa uma relação de "um para muitos" entre o modelo Fornecedor e o modelo FornecedorProduto
        public virtual ICollection<FornecedorProduto> FornecedorProdutos { get; set; }

    }
}