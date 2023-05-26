using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IDGS902_Tema1.Models
{
    // Clase que maneja la lógica y los datos relacionados con las Cajas Dinámicas
    public class CajasDinamicas
    {

        
        public List<string> Inputs { get; set; }         // Lista de elementos de entrada dinámicos
        public int? NumInputs { get; set; }              // Número de inputs proporcionados
        public int SumaTotal { get; set; }               // Suma total de los números ingresados
        public List<int> NumerosRepetidos { get; set; }  // Lista de números repetidos



        public void CajasDinamicasModel(int? numInputs)
        {
            if (numInputs.HasValue && numInputs.Value > 0)
            {
                List<string> inputs = new List<string>();

                // Genera los elementos de entrada dinámicos y los agrega a la lista
                for (int i = 0; i < numInputs.Value; i++)
                {
                    inputs.Add($"<br><input type='text' name='input{i + 1}' class='form-control' />");
                }

                Inputs = inputs;
            }
            else
            {
                // Si no se proporcionó un número válido de inputs, se asigna null a la lista de inputs
                Inputs = null;
            }

            // Almacena el número de inputs proporcionados
            NumInputs = numInputs;
        }


        public void CalculosCDPostModel(FormCollection form)
        {
            var numeros = new List<int>();

            // Recorre las claves del formulario enviado
            foreach (var key in form.Keys)
            {
                // Verifica si la clave comienza con 'input'
                if (key.ToString().StartsWith("input"))
                {
                    int numero;

                    // Intenta convertir el valor de la clave en un número entero
                    if (int.TryParse(form[key.ToString()], out numero))
                    {
                        // Agrega el número a la lista 'numeros'
                        numeros.Add(numero);
                    }
                }
            }

            // Calcula la suma total de los números en la lista 'numeros'
            int sumaTotal = numeros.Sum();
            SumaTotal = sumaTotal;

            // Crea un diccionario para contar las ocurrencias de cada número y una lista para almacenar los números repetidos
            Dictionary<int, int> contador = new Dictionary<int, int>();
            List<int> numerosRepetidos = new List<int>();

            // Recorre la lista 'numeros'
            foreach (int numero in numeros)
            {
                // Si el número ya existe en el diccionario 'contador', incrementa su contador y agrega el número a 'numerosRepetidos' si aún no está presente
                if (contador.ContainsKey(numero))
                {
                    contador[numero]++;
                    if (!numerosRepetidos.Contains(numero))
                    {
                        numerosRepetidos.Add(numero);
                    }
                }
                else
                {
                    // Si el número no existe en el diccionario 'contador', lo agrega con un contador inicial de 1
                    contador[numero] = 1;
                }
            }

            // Asigna la lista de números repetidos a la propiedad correspondiente
            NumerosRepetidos = numerosRepetidos;
        }
    }
}
