using IDGS902_Tema1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS902_Tema1.Services
{
    public class PulquesServices
    {
        public List<Pulques> ObtenerPulque()
        {
            var pulque1 = new Pulques()
            {
                Producto = "Pulque1",
                Descripcion = "Mango Piña",
                Litros = 20,
                Creacion = new DateTime(2023, 11, 5)
            };
            var pulque2 = new Pulques()
            {
                Producto = "Pulque2",
                Descripcion = "Frutos Rojos",
                Litros = 35,
                Creacion = new DateTime(2023, 5, 10)
            };
            return new List<Pulques> { pulque1,pulque2 };
        }
    }
}