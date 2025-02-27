using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_filmes_senai.Domains
{
    public class Filme
    {
        [Key]
        public Guid IdFilme { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O titulo do filme é obrigatório!")]
        public String? Titulo { get; set; }

        /// <summary>
        /// Referência da tabela Genero
        /// </summary>
        public Guid IdGenero { get; set; }
        [ForeignKey("IdGenero")]
        public Genero? Genero { get; set; }
    }
}
