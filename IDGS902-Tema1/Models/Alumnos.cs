using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS902_Tema1.Models
{
    public class Alumnos
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int Edad { get; set; }

        public bool Activo { get; set; }

        public DateTime Inscripcion { get; set; }

    }
}