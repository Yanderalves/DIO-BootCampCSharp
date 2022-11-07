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

        [HttpPost]
        public IActionResult Create(Contato contato){
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        } 
    }
}