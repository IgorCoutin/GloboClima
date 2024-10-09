using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboClima.API.Dtos.User
{
    public class LoginDto
    {
        public string email { get; set; }
        public string senha { get; set; }
       
    }
}