using Fiap.Anuncios.MVC.WEB.Models;
using Fiap.Anuncios.MVC.WEB.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Fiap.Anuncios.MVC.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario, string password2)
        {
            if (usuario.Password != password2)
            {
                ModelState.AddModelError("Password", "Senhas Não Conferem");
                return View();
            }
            if (_unit.UsuarioRepository.SearchFor(u => u.UserName == usuario.UserName).Count != 0)
            {
                ModelState.AddModelError("UserName", "Usuário já existe");
            }
            if (ModelState.IsValid)
            {
                _unit.UsuarioRepository.Add(usuario);
                _unit.Save();
                TempData["msg"] = "Usuário Cadastrado!";
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(Usuario usuario, string returnUrl)
        {
            var user = _unit.UsuarioRepository.Logar(usuario.UserName, usuario.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else
            {
                TempData["msg"] = "Usuário ou senha Inválidos";
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}