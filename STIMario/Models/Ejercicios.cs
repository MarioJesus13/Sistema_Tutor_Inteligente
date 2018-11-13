using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace STIMario.Models
{
    public class Ejercicios
    {
        [Key]
        public int IDejercicio { get; set; }
        public String NombreEjercicio { get; set; }
        public int Puntaje { get; set; }
    }
}
