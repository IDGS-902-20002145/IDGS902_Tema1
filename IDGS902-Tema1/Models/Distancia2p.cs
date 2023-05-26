using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS902_Tema1.Models
{
    public class Distancia2p
    {
        public float  x1 { get; set; }
        public float  x2 { get; set; }

        public float  y1 { get; set; }
        public float  y2 { get; set; }

        public float Res {get; set; }

        public float CalcularDistancia(float x1, float y1, float x2, float y2)
        {
            float distancia = (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Res = distancia;
            return Res;
        }

    }
}