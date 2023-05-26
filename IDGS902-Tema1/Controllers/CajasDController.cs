using System.Web.Mvc;
using IDGS902_Tema1.Models;

namespace IDGS902_Tema1.Controllers
{
    // Controlador para manejar las acciones relacionadas con las Cajas Dinámicas
    public class CajasDController : Controller
    {
        private CajasDinamicas cajasDinamicas;

        // Constructor del controlador, inicializa la instancia de la clase CajasDinamicas
        public CajasDController()
        {
            cajasDinamicas = new CajasDinamicas();
        }

       
        public ActionResult CajasDinamicas(int? numInputs)
        {
            // Se llama al método de la clase CajasDinamicas para generar los elementos de entrada dinámicos
            cajasDinamicas.CajasDinamicasModel(numInputs);

            // Se asigna los valores y el número de inputs a la ViewBag para usarlos en la vista
            ViewBag.Inputs = cajasDinamicas.Inputs;
            ViewBag.NumInputs = cajasDinamicas.NumInputs;

            // Devuelve la vista correspondiente
            return View();
        }

        
        [HttpPost, ActionName("CalculosCD")]
        public ActionResult CalculosCDPost(FormCollection form)
        {
            // Llama al método de la clase CajasDinamicas para realizar los cálculos
            cajasDinamicas.CalculosCDPostModel(form);

            // Asigna la suma total y los números repetidos a la ViewBag para usarlos en la vista
            ViewBag.SumaTotal = cajasDinamicas.SumaTotal;
            ViewBag.NumerosRepetidos = cajasDinamicas.NumerosRepetidos;

            // Devuelve la vista correspondiente
            return View();
        }
    }
}
