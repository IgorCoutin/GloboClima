using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GloboClima.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        // Este endpoint requer um token JWT válido para acesso
        [HttpGet("protected")]
        [Authorize]
        public IActionResult GetProtectedData()
        {
            return Ok(new { message = "Você acessou um endpoint protegido!" });
        }

        // Este endpoint é público e não requer autenticação
        [HttpGet("public")]
        public IActionResult GetPublicData()
        {
            return Ok(new { message = "Este é um endpoint público, sem necessidade de autenticação." });
        }
    }
}
