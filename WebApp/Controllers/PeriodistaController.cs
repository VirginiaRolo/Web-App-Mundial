using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Models;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    public class PeriodistaController : Controller
    {
        private Sistema s = Sistema.GetInstancia();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "OPE")
            {
                List<Periodista> per = s.GetPeriodistas();
                return View(per);
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Periodista per)
        {
            try
            {
                s.AltaFuncionario(per);
                ViewBag.msg = "Alta Correcta";
            }
            catch (Exception e)
            {
                ViewBag.msg = "Error: " + e.Message;
            }
            return View();

        }


    }
}
