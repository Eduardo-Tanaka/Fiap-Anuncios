using Fiap.Anuncios.MVC.WEB.DataAccess;
using Fiap.Anuncios.MVC.WEB.Models;
using Fiap.Anuncios.MVC.WEB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.Anuncios.MVC.WEB.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        private AnunciosContext _context = new AnunciosContext();

        private IGenericRepository<Categoria> _categoriaRepository;

        private IGenericRepository<Anuncio> _anuncioRepository;

        private IUsuarioRepository _usuarioRepository;

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (_usuarioRepository == null)
                {
                    _usuarioRepository = new UsuarioRepository(_context);
                }
                return _usuarioRepository;
            }
        }

        public IGenericRepository<Anuncio> AnuncioRepository
        {
            get
            {
                if (_anuncioRepository == null)
                {
                    _anuncioRepository = new GenericRepository<Anuncio>(_context);
                }
                return _anuncioRepository;
            }
        }

        public IGenericRepository<Categoria> CategoriaRepository
        {
            get
            {
                if (_categoriaRepository == null)
                {
                    _categoriaRepository = new GenericRepository<Categoria>(_context);
                }
                return _categoriaRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}