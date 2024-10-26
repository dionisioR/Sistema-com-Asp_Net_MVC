using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models {
    public class TipoDocumento {
        [Key]
        public int TipoDocumentoID { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name ="Tipo de Documento")]
        public string Descricao { get; set; }

        // Tem uma coleção de funcionários
        // essa linha manda para a classe funcionário uma coleção contendo as informações do tiop documento
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}