using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fiap.Anuncios.MVC.WEB.Models
{
    [Table("T_CATEGORIA")]
    public class Categoria
    {
        [Column("CD_CATEGORIA")]
        public int CategoriaId { get; set; }
        [Column("NM_CATEGORIA")]
        [Required(ErrorMessage = "Nome Obrigatório")]
        public string Nome { get; set; }
        public ICollection<Anuncio> Anuncios { get; set; }
    }
}