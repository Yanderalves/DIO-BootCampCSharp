using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
            [HttpGet("ObterDataEHoraAtual")]
            public IActionResult ObterDataEHora(){
                var obj = new {
                    Data = DateTime.Now.Date.ToShortDateString(),
                    Hora = DateTime.Now.Hour
                };

                return Ok(obj);
            }
            [HttpGet("Apresentar/{nome}")]
            public IActionResult Apresentar(string nome){
                var mensagem = $"Olá {nome}, CLUBE DE REGATAS DO FLAMENGO É GIGANTESCO";
                return Ok(new {mensagem});
            }
    }
}