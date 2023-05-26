using IDGS902_Tema1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS902_Tema1.Services
{
    public class DiccionarioService
    {
        public void AgregarDiccionario(Diccionario dc) 
        {
            var pEspañol = dc.Espanol;
            var pIngles = dc.Ingles;

            var datos = pEspañol.ToUpper() + "=" + pIngles.ToUpper() + Environment.NewLine;

            var archivo = HttpContext.Current.Server.MapPath("~/App_Data/Diccionario.txt");
            File.AppendAllText(archivo, datos);
        }

        public Array LeerArchivo()
        {
            Array palDic = null;
            var datos = HttpContext.Current.Server.MapPath("~/App_Data/Diccionario.txt");
            if (File.Exists(datos))
            {
                palDic = File.ReadAllLines(datos);
            }
            return palDic;
        }

        public string BuscarPalabra(Diccionario dc)
        {
            var palabraBuscar = dc.PalabraBuscar.ToUpper();
            var datos = HttpContext.Current.Server.MapPath("~/App_Data/Diccionario.txt");
            var lineasDiccionario = File.ReadAllLines(datos);
            var respuesta = "";

            foreach (var linea in lineasDiccionario)
            {
                var palabras = linea.Split('=');
                var spanish = palabras[0].Trim();
                var english = palabras[1].Trim();

                if (dc.Idioma == "inglés" && spanish == palabraBuscar)
                {
                    respuesta = english;
                    break;
                }
                else if (dc.Idioma == "español" && english == palabraBuscar)
                {
                    respuesta = spanish;
                    break;
                }
            }

            if(respuesta == "")
            {
                respuesta = @"<div class=""alert alert-danger"" role=""alert"">
                No se encontraron resultados
            </div>";
            }
            else
            {
                respuesta = @"<div class=""alert alert-success"" role=""alert"">
                <h1>La traducción es: " + respuesta + @"</h1>
            </div>";
            }

            return respuesta;
        }

    }
}