using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//using GloboClima.Contexts.ApplicationDbContext
// using GloboClima.API.Models.Geral;


namespace GloboClima.API.Models
{
    public class User
    {
        [Key]
        public int codigo { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; } = String.Empty;
         public int grupo { get; set; }
       
        
        public Grupos GrupoJoin { get; set; }
        
    }
}