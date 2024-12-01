using back_Lozgar.DTO;
using back_Lozgar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_Lozgar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly appDBcontext _appdbcontext;

        public ClienteController(appDBcontext appDBcontext)
        {
            _appdbcontext = appDBcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _appdbcontext.Cliente.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _appdbcontext.Cliente.FindAsync(id);
            if(cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _appdbcontext.Cliente.Add(cliente);
            await _appdbcontext.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id_Cliente }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if(id != cliente.Id_Cliente)
            {
                return BadRequest();
            }

            _appdbcontext.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _appdbcontext.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException)
            {
                if(!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _appdbcontext.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _appdbcontext.Cliente.Remove(cliente);
            await _appdbcontext.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _appdbcontext.Cliente.Any(e => e.Id_Cliente == id);
        }

    }
}
