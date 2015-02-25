using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap.Anuncios.MVC.WEB.Models
{
    public class Anuncio
    {
        public int AnuncioId { get; set; }
        public Categoria Categoria { get; set; }
        [Required(ErrorMessage = "Categoria Obrigatória")]
        public int CategoriaId { get; set; }
        public string Comentario { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        [Required(ErrorMessage = "Descrição Obrigatória")]
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Valor Obrigatório")]
        public decimal Valor { get; set; }
    }
}