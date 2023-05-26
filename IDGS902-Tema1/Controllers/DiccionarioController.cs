using Antlr.Runtime;
using IDGS902_Tema1.Models;
using IDGS902_Tema1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS902_Tema1.Controllers
{
    public class DiccionarioController : Controller
    {

        public ActionResult RegistrarDiccionario()
        {
            var leer = new DiccionarioService();
            ViewBag.Datos = leer.LeerArchivo();
            return View();
        }
        // POST: Diccionario
        [HttpPost]
        public ActionResult RegistrarDiccionario(Diccionario dic)
        {
            var ope1 = new DiccionarioService();           
            
            ope1.AgregarDiccionario(dic);
            ViewBag.Datos = ope1.LeerArchivo();
            return View(dic);
        }

        [HttpGet]
        public ActionResult BuscarDiccionario()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BuscarDiccionario(Diccionario dic)
        {
            var buscar = new DiccionarioService();
            ViewBag.Traduccion = buscar.BuscarPalabra(dic);

            return View();
        }
    }
}