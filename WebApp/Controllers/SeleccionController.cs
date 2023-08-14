using Dominio;
using Dominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class SeleccionController : Controller
    {
        private Sistema s = Sistema.GetInstancia();
        public IActionResult VerJugadores(string nombrePais)
        {
            return View(s.GetSelecciones(nombrePais));
        }

        public IActionResult VerSeleccionesGoleadoras()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "OPE")
            {
                List<Seleccion> sel = s.GetSeleccionesGoleadoras();
                return View(sel);
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

    }
}
