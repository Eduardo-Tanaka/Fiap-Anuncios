using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap.Anuncios.MVC.WEB.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome Obrigatório")]
        public string UserName { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha Obrigatório")]
        public string Password { get; set; }
    }
}