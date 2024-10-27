using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models {
    public class Funcionario {
        [Key]
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Primeiro nome")]
        [MaxLength(30, ErrorMessage = "O nome n?o pode ter mais de 30 caracteres")]
        [MinLength(2, ErrorMessage = "O nome precisa ter pelo menos 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)] // para casas decimais
        public decimal Salario { get; set; }

        [Display(Name = "Comissão")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)] // para Porcentagem
        public float Comissao { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] // para casas decimais
        //[DataType(DataType.Date)]  // Input type='date'
        public DateTime Nascimento { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] // para casas decimais
        //[DataType(DataType.Date)]
        public DateTime Cadastro { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [NotMapped]
        public int Idade {
            get {
                var idade = DateTime.Now.Year - Nascimento.Year;
                if (DateTime.Now < Nascimento.AddYears(idade)) {
                    idade--;
                }
                return idade;
            }
        }

        // relacionamento entre os modelos/tabelas
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Tipo de Documento")]
        public int TipoDocumentoId { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}