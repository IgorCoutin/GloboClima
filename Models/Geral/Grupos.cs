using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GloboClima.Api.Models
{
    public class Grupos
    {
        [Key]
        public int codigo { get; set; }
        public int segmento { get; set; }
        public string nome { get; set; }
          
    }
}