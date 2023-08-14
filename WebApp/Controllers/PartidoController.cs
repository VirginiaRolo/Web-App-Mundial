using Dominio;
using Dominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class PartidoController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "OPE")
            {
                List<Partido> par = s.GetPartidos();
                return View(par);
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        #region Para Periodistas
        public IActionResult Cerrados()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "PER")
            {
                List<Partido> par = s.GetPartidosFinalizados();
                return View(par);
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        #endregion

        #region Para Operadores
        public IActionResult Buscar()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "OPE")
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        [HttpPost]
        public IActionResult Buscar(DateTime f1, DateTime f2)
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "OPE")
            {
                try
                {
                    List<Partido> lp = s.GetPartidosEntreFechas(f1, f2);
                    return View(lp);
                }
                catch (Exception e)
                {
                    ViewBag.msgBusqueda = e.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult BuscarPorPeriodista()
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "OPE")
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        [HttpPost]
        public IActionResult BuscarPorPeriodista(string email)
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "OPE")
            {
                try
                {
                    List<Partido> lp = s.GetPartidosDePeriodista(email);
                    return View(lp);
                }
                catch (Exception e)
                {
                    ViewBag.msgBusqueda = "Error: " + e.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        public IActionResult FinalizarPartido(int id)
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "OPE")
            {
                Partido par = s.GetPartido(id);
                return View(par);
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        [HttpPost]
        public IActionResult FinalizarPartido(int id, bool IsChecked)
        {
            if (IsChecked)
            {
                Partido par = s.GetPartido(id);
                par.FinalizarPartido();
                ViewBag.msg = "Finalizado con éxito";
                return View(par);
            }
            else
            {
                Partido par = s.GetPartido(id);
                ViewBag.msg = "Debe seleccionar el checkbox";
                return View(par);               
            }
           
        }
        #endregion










    }
}
