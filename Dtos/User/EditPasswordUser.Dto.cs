
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboClima.API.Dtos.User
{
    public class EditPasswordUser
    {
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }              
        public string? novaSenha { get; set; }
        public int grupo { get; set; }

    }
}

