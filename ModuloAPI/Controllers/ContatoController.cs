using Microsoft.AspNetCore.Mvc;
using Context;
using Entities;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context){
            _context = context;
        }   

        [HttpPost("AdicionarContato")]
        public IActionResult CriarContato(Contato contato){
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        } 

        [HttpGet("ObterPorId/{id}")]
        public IActionResult ObterPorId(int id){
            var contato = _context.Contatos.Find(id);

            if(contato == null)
                return NotFound();
            else
                return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome){
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));

            return Ok(contatos);
        }

        [HttpGet("ObterPorTelefone/{telefone}")]
        public IActionResult ObterPorTelefone(string telefone){
            var contato = _context.Contatos.Where(x => x.Telefone == telefone);

            if(contato == null)
                return NotFound();
            
            return Ok(contato);
        }

        [HttpGet("ObterPorStatus/{status}")]
        public IActionResult ObterPorStatus(bool status){
            var contatos = _context.Contatos.Where(x => x.Ativo == status);
            
            if(contatos == null)
                return NotFound();
            
            return Ok(contatos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato){
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
                return NotFound();
           
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;
            

            _context.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
                return NotFound();
            
            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}