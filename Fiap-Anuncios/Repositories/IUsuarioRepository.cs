using Fiap.Anuncios.MVC.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Anuncios.MVC.WEB.Repositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario Logar(string user, string senha);
    }
}
