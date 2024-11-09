using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models {
    public class TipoDocumento {
        [Key]
        [Display(Name ="Tipo de Documento")]
        public int TipoDocumentoID { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name ="Tipo de Documento")]
        public string Descricao { get; set; }

        // Tem uma coleção de funcionários
        //  Representa uma relação de "um para muitos" entre o modelo TipoDocumento e o modelo Funcionario
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        public virtual ICollection<Customizar> Customizacao { get; set; }
    }
}