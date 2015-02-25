using Fiap.Anuncios.MVC.WEB.DataAccess;
using Fiap.Anuncios.MVC.WEB.Models;
using Fiap.Anuncios.MVC.WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.Anuncios.MVC.WEB.Repositories
{
    class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AnunciosContext context) : base(context) { }

        public Usuario Logar(string user, string senha)
        {
            senha = CriptografiaUtils.CriptografarSHA256(senha);
            return _dbSet.Where(u => u.UserName == user && u.Password == senha).FirstOrDefault();
        }

        public override void Add(Usuario entity)
        {
            entity.Password = CriptografiaUtils.CriptografarSHA256(entity.Password);
            base.Add(entity);
        }
    }
}