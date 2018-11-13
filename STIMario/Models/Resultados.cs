using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace STIMario.Models
{
    public class Resultados
    {
        [Key]
       public int IDresultados { get; set; }
       public int RespuestasCorrectas { get; set; }
        public int RespuestasIncorrectas { get; set;
        }
    }
}
