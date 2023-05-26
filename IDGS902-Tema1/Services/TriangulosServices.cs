using IDGS902_Tema1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace IDGS902_Tema1.Services
{
    public class TriangulosServices
    {
        // Método para verificar si los puntos forman un triángulo válido
        public bool VerificarTriangulo(Triangulos t)
        {
            // Imprime las coordenadas de los puntos del triángulo
            Debug.WriteLine("X1: " + t.X1);
            Debug.WriteLine("Y1: " + t.Y1);
            Debug.WriteLine("X2: " + t.X2);
            Debug.WriteLine("Y2: " + t.Y2);
            Debug.WriteLine("X3: " + t.X3);
            Debug.WriteLine("Y3: " + t.Y3);

            // Calcula las distancias entre los puntos del triángulo
            t.punto1 = CalcularDistancia(t.X1, t.Y1, t.X2, t.Y2);
            Debug.WriteLine("Distancia 1: " + t.punto1);
            t.punto2 = CalcularDistancia(t.X1, t.Y1, t.X3, t.Y3);
            Debug.WriteLine("Distancia 2: " + t.punto2);
            t.punto3 = CalcularDistancia(t.X2, t.Y2, t.X3, t.Y3);
            Debug.WriteLine("Distancia 3: " + t.punto3);

            // Verifica si las distancias cumplen la desigualdad triangular para formar un triángulo válido
            if (t.punto1 < t.punto2 + t.punto3 && t.punto2 < t.punto1 + t.punto3 && t.punto3 < t.punto1 + t.punto2)
                return true;  // Los puntos forman un triángulo válido

            return false;  // Los puntos no forman un triángulo válido
        }

       
        public void CalcularTipoTriangulo(Triangulos t)
        {
            // Calcula las distancias entre los puntos del triángulo
            t.punto1 = CalcularDistancia(t.X1, t.Y1, t.X2, t.Y2);
          
            t.punto2 = CalcularDistancia(t.X1, t.Y1, t.X3, t.Y3);
          
            t.punto3 = CalcularDistancia(t.X2, t.Y2, t.X3, t.Y3);
           

            // Verifica las distancias para determinar el tipo de triángulo
            if (Convert.ToInt16(t.punto1) == Convert.ToInt16(t.punto2) && Convert.ToInt16(t.punto2) == Convert.ToInt16(t.punto3))
            {
                t.TipoTriangulo = "Equilátero";
            }
            else if (t.punto1 == t.punto2 || t.punto1 == t.punto3 || t.punto2 == t.punto3)
            {
                t.TipoTriangulo = "Isósceles";
            }
            else
            {
                t.TipoTriangulo = "Escaleno";
            }
        }

        // Método para calcular el área del triángulo
        public decimal CalcularArea(Triangulos t)
        {
            // Calcula las distancias entre los puntos del triángulo
            t.punto1 = CalcularDistancia(t.X1, t.Y1, t.X2, t.Y2);

            t.punto2 = CalcularDistancia(t.X1, t.Y1, t.X3, t.Y3);

            t.punto3 = CalcularDistancia(t.X2, t.Y2, t.X3, t.Y3);

            // Calcula el semiperímetro del triángulo
            decimal sp = (t.punto1 + t.punto2 + t.punto3) / 2;

            // Calcula el área del triángulo utilizando la fórmula 
            t.Area = (decimal)Math.Sqrt((double)(sp * (sp - t.punto1) * (sp - t.punto2) * (sp - t.punto3)));

            return t.Area;  // Devuelve el área del triángulo
        }

        // Método privado para calcular la distancia entre dos puntos
        private decimal CalcularDistancia(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            // Calcula la distancia utilizando la fórmula de distancia euclidiana
            return (decimal)Math.Sqrt((double)(x2 - x1) * (double)(x2 - x1) + (double)(y2 - y1) * (double)(y2 - y1));
        }
    }


}
