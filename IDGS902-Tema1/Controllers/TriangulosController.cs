using IDGS902_Tema1.Models;
using IDGS902_Tema1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS902_Tema1.Controllers
{
    public class TriangulosController : Controller
    {
        public ActionResult VerificarTriangulo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarTriangulo(Triangulos t)
        {
            var trianguloServices = new TriangulosServices();

            if (trianguloServices.VerificarTriangulo(t))
            {
                trianguloServices.CalcularTipoTriangulo(t);
                trianguloServices.CalcularArea(t);
            }
            else
            {
                t.TipoTriangulo = "Los puntos indicados no forman un triángulo"; 
                t.Area = 0;
                ViewBag.Area = "No se puede calcular el area debido a que no es un triángulo";
            }

            return View(t);
        }

    }
}