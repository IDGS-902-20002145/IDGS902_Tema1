using IDGS902_Tema1.Models;
using IDGS902_Tema1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS902_Tema1.Controllers
{
    public class NuevoController : Controller
    {
        public ActionResult Inicio()
        {
            ViewBag.Message = "Está es la nueva vista.";
            return View();
        }


        public ActionResult OperasBas(string n1, string n2, string operacion)
        {
            int num1 = Convert.ToInt32(n1);
            int num2 = Convert.ToInt32(n2);
            int res = 0;

            switch (operacion)
            {
                case "suma":
                    res = num1 + num2;
                    break;
                case "resta":
                    res = num1 - num2;
                    break;
                case "multiplicacion":
                    res = num1 * num2;
                    break;
                case "division":
                    res = num1 / num2;
                    break;
                
            }

            ViewBag.Res = res;
            return View();
        }


        public ActionResult OperasBas2(Calculos cls)
        {
            var  model = new Calculos();
            model.Res=cls.Num1 + cls.Num2;
           

            ViewBag.Res = model.Res;
            return View(model);
        }

        public ActionResult Distancia2Puntos(Distancia2p d2p)
        {
            var model = new Distancia2p();
            model.Res = model.CalcularDistancia(d2p.x1, d2p.y1, d2p.x2, d2p.y2);
            ViewBag.Res = model.Res;
            return View(model);
        }

        public ActionResult MuestraPulques()
        {
            var pulques1 = new PulquesServices();
            var model = pulques1.ObtenerPulque();
            return View(model);
        }

        public ActionResult MuestraPulques2()
        {
            var pulques1 = new PulquesServices();
            var model = pulques1.ObtenerPulque();
            return View(model);
        }

    }
}
