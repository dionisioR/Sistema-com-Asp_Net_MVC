using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models {
    public class Customizar {
        [Key]
        public int CustomizarId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campor obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Documento")]
        public string Documento { get; set; }

        public int TipoDocumentoID { get; set; }

        public string NomeCompleto {
            get {
                return string.Format("{0} - {1}", Nome, Telefone);
            }
        }
        // Para relecionar
        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual ICollection<Ordem> Ordem { get; set; }
    }
}