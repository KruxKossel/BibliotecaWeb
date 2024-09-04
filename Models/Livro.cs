using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.Models
{
    public class Livro
    {
        [Key]
        [DisplayName("Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [DisplayName("Título")]
        public string Titulo { get; set; } = string.Empty;

        [DisplayName("Autor(es)")]
        public string? Autor { get; set; }

    }
}