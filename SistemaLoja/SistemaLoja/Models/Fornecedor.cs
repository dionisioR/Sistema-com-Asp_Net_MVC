using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models {
    public class Fornecedor {
        [Key]
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        // Representa uma relação de "um para muitos" entre o modelo Fornecedor e o modelo FornecedorProduto

    }
}