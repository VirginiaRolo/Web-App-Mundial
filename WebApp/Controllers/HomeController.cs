using Dominio;
using Dominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private Sistema s = Sistema.GetInstancia();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                ViewBag.msg = "Mundial Qatar 2022 - Bienvenido";
            }

            List<Seleccion> sel = s.GetSelecciones();
            return View(sel);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            
            Funcionario logueado = s.Login(email, pass);
          
            if (logueado != null)
            {
                HttpContext.Session.SetInt32("LogueadoId", logueado.Id);
                HttpContext.Session.SetString("LogueadoRol", logueado.GetRol());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msg = "Error en los datos";
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

    }
}   
