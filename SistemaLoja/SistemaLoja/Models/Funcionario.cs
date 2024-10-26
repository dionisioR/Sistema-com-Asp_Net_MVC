using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models {
    public class Funcionario {
        [Key]
        public int FuncionarioId { get; set; }

        [Required (ErrorMessage ="O campo {0} é obrigatório!")]
        [Display(Name ="Primeiro nome")]
        [MaxLength(100, ErrorMessage = "O nome n?o pode ter mais de 100 caracteres")]
        [MinLength(2, ErrorMessage = "O nome precisa ter pelo menos 2 caracteres")]
        public string Nome { get; set; }

        [Required (ErrorMessage ="O campo {0} é obrigatório!")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Display(Name ="Salário")]
        public decimal Salario { get; set; }

        [Display(Name = "Comissão")]
        public float Comissao { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date)]
        public DateTime Cadastro { get; set; }

        [Display(Name ="E-mail")]
        public string  Email  { get; set; }

        // relacionamento entre os modelos/tabelas
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Tipo de Documento")]
        public int TipoDocumentoId { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}