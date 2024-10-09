using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GloboClima.API.Contexts;
using GloboClima.API.Dtos.User;
using GloboClima.API.Models;
using GloboClima.API.Models.Geral;
using GloboClima.API.Services;
using GloboClima.API.Models.Responses;
using System.Collections.Immutable;


namespace GloboClima.API.Controllers
{
    [Authorize]
    [Route("api/geral")]
    [ApiController]
    public class GeralController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly HelperService _helperService;
        private readonly IConfiguration _config;
        private readonly ILogger<GeralController> _logger;
        private readonly TokenService _tokenService;

        public GeralController(ILogger<GeralController> logger, ApplicationDbContext context, IConfiguration config, HelperService helperService, TokenService tokenService)
        {
            _logger = logger;
            _context = context;
            _config = config;
            _helperService = helperService;
            _tokenService = tokenService;
        }

        [HttpGet("grupos")]
        public async Task<IActionResult> GetGrupos()
        {
            Response<List<Coordenacoes>> response = new Response<List<Coordenacoes>>();

            var token = _tokenService.GetTokenFromCookie(HttpContext);

            if (token == null)
            {
                response.Success = false;
                response.Message = "Token não encontrado";
                return BadRequest(response);
            }

            var profileId = int.Parse(_tokenService.GetTokenValue(token, TokenService.ClaimType.profileId));
            var userCoord = int.Parse(_tokenService.GetTokenValue(token, TokenService.ClaimType.coordId));

            var view = _helperService.GetView(profileId);

        }

    } 
}
