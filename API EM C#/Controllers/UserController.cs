using API_EM_C_.InfraEstrutura;
using API_EM_C_.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly ConnectionContex _context;

    public UserController(ITokenService tokenService, ConnectionContex context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel login)
    {
        // Aqui valida o usuário no banco (ajuste para seu modelo)
        var usuario = _context.LoginModel
            .FirstOrDefault(u => u.Usuario == login.Usuario && u.Senha == login.Senha);

        if (usuario == null)
            return Unauthorized("Usuário ou senha inválidos.");

        var token = _tokenService.GenerateToken(login.Usuario);

        return Ok(new { token });
    }
}
