using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboClima.API.Dtos.User
{
    public class CreateUserDto
    {
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; } = String.Empty;
        public int grupo { get; set; }
       
    }
}