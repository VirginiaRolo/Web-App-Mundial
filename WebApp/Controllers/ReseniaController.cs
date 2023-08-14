using Dominio;
using Dominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApp.Controllers
{

    public class ReseniaController : Controller
    {
        private Sistema s = Sistema.GetInstancia();


        public IActionResult NuevaResenia(int id)
        {
            if (HttpContext.Session.GetString("LogueadoRol") == "PER")
            {
                ViewBag.idPartido = id;
                Partido b = s.GetPartido(id);               
                TempData["PartidoB"] = id;
                ViewBag.SeleccionesEnfrentadas = b.MostrarSeleccionesEnfrentadas();
                return View();               
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        [HttpPost]
        public IActionResult NuevaResenia(Resenia r)
        {
            int? idL = HttpContext.Session.GetInt32("LogueadoId");
            int pIdRecuperado = Int32.Parse(TempData["PartidoB"].ToString());
            Partido parRecuperado = s.GetPartido(pIdRecuperado);

            try
            {                
                s.AsociarNuevaResenia(r, idL, parRecuperado);
                ViewBag.msg = "Alta Correcta";
                return View(r);               
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return View(r);
            }
        }

        public IActionResult VerResenias()
        {

            if (HttpContext.Session.GetString("LogueadoRol") == "PER")
            {
                int? idL = HttpContext.Session.GetInt32("LogueadoId");
                List<Resenia> r = s.GetReseniasDePeriodista(idL);

                if (r.Count == 0)
                {
                    ViewBag.msg = "No existen reseñas";
                }
                return View(r);

            }
            
            return RedirectToAction("AccesoDenegado", "Home");

        }

        public IActionResult VerReseniasDeP(int id)
        {
            //ViewBag.idPartido = idP;
            //Partido b = s.GetPartido(idP);
            //ViewBag.NombreGrupo = s.GetNombreGrupo(idP);            
            if (HttpContext.Session.GetString("LogueadoRol") == "OPE")
            {
                List<Resenia> r = s.GetReseniasDePeriodista(id);
                return View(r);
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }




    }
}
