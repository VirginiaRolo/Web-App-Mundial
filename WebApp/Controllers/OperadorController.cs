using Dominio;
using Dominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class OperadorController : Controller
    {
        private Sistema s = Sistema.GetInstancia();
        public IActionResult Index()
        {
            return View();

        }
    }
}
