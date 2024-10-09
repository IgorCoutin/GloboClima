using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GloboClima.API.Contexts;
using GloboClima.API.Models;
using GloboClima.API.Dtos.User;
using GloboClima.API.Services;
using GloboClima.API.Models.Responses;
using GloboClima.API.Models.Geral;


namespace GloboClima.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly TokenService _tokenService;
        private readonly PasswordService _passwordService;

        public UserController(ILogger<UserController> logger, ApplicationDbContext context, TokenService tokenService, PasswordService passwordService)
        {
            _logger = logger;
            _context = context;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var response = new Response<LoggedUserDto>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.email == login.email);
                
                if (user == null || !_passwordService.VerifyPassword(user, user.senha, login.senha))
                {
                    response.Success = false;
                    response.Message = "Usuário ou senha inválidos";
                    return BadRequest(response);
                }

                var loggedUser = new LoggedUserDto
                {
                    Codigo = user.codigo,
                    Nome = user.nome,
                    Email = user.email,
                    Grupo = user.grupo
                };

                string jwt = _tokenService.GenerateToken(loggedUser);
                response.Data = loggedUser;
                response.Success = true;
                response.Message = "Login realizado com sucesso";
                return Ok(new { Token = jwt, response });
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro no login: " + ex.Message);
                response.Success = false;
                response.Message = "Erro ao tentar realizar o login";
                return StatusCode(500, response);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto userDto)
        {
            var response = new Response<LoggedUserDto>();

            var newUser = new User
            {
                nome = userDto.nome,
                email = userDto.email,
                grupo = userDto.grupo,
                senha = _passwordService.HashPassword(new User(), userDto.senha) // Hasheia a senha
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            var loggedUser = new LoggedUserDto
            {
                Codigo = newUser.codigo,
                Nome = newUser.nome,
                Email = newUser.email,
                Grupo = newUser.grupo
            };

            response.Data = loggedUser;
            response.Success = true;
            response.Message = "Usuário registrado com sucesso";
            return Ok(response);
        }
    }
}
