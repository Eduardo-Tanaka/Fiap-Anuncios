using Fiap.Anuncios.MVC.WEB.Models;
using Fiap.Anuncios.MVC.WEB.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Anuncios.MVC.WEB.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Categoria categoria)
        {
            if (_unit.CategoriaRepository.SearchFor(c => c.Nome == categoria.Nome).Count != 0)
            {
                ModelState.AddModelError("Nome", "Categoria já cadastrada");
            }
            if (ModelState.IsValid)
            {
                _unit.CategoriaRepository.Add(categoria);
                _unit.Save();
                TempData["msg"] = "Categoria Cadastrada";
                return View();
            }
            else
            {
                return View(categoria);
            }


        }

        public ActionResult Listar()
        {
            return View(_unit.CategoriaRepository.List());
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}