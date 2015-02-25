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
    public class AnuncioController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            ViewBag.Categorias = new SelectList(_unit.CategoriaRepository.List(), "CategoriaId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                _unit.AnuncioRepository.Add(anuncio);
                _unit.Save();
                TempData["msg"] = "Anúncio Cadastrado";
                return RedirectToAction("Listar");
            }
            else
            {
                return View(anuncio);
            }

        }

        public ActionResult Listar()
        {
            return View(_unit.AnuncioRepository.List());
        }

        public ActionResult Buscar(string Titulo)
        {
            var lista = _unit.AnuncioRepository.SearchFor(a => a.Titulo == Titulo);
            return PartialView("_Tabela", lista);
        }

        [HttpPost]
        public ActionResult Aprovar(int id)
        {
            var anuncio = _unit.AnuncioRepository.SearchById(id);
            anuncio.Status = "Aprovado";
            _unit.Save();
            TempData["msg"] = "Anúncio Aprovado";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Reprovar(int id, string Comentario)
        {
            var anuncio = _unit.AnuncioRepository.SearchById(id);
            anuncio.Status = "Reprovado";
            anuncio.Comentario = Comentario;
            _unit.Save();
            TempData["msg"] = "Anúncio Reprovado";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            ViewBag.Categorias = new SelectList(_unit.CategoriaRepository.List(), "CategoriaId", "Nome");
            return View(_unit.AnuncioRepository.SearchById(id));
        }

        [HttpPost]
        public ActionResult Editar(Anuncio anuncio)
        {
            _unit.AnuncioRepository.Update(anuncio);
            _unit.Save();
            TempData["msg"] = "Anuncio Alterado";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Remover(int id)
        {
            _unit.AnuncioRepository.Delete(id);
            _unit.Save();
            TempData["msg"] = "Anuncio Removido";
            return RedirectToAction("Listar");
        }
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}