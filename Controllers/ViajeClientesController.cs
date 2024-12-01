using back_Lozgar.DTO;
using back_Lozgar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_Lozgar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeClientesController : ControllerBase
    {
        private readonly appDBcontext _appdbcontext;

        public ViajeClientesController(appDBcontext appDBcontext)
        {
            _appdbcontext = appDBcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViajeClientes>>> GetViajeClientes()
        {
            return await _appdbcontext.ViajeClientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViajeClientes>> GetViajeCliente(int id)
        {
            var vc = await _appdbcontext.ViajeClientes.FindAsync(id);

            if (vc == null)
            {
                return NotFound();
            }

            return vc;
        }

        [HttpPost]
        public async Task<ActionResult<ViajeClientes>> PostViajesClientes(ViajeClientes vc)
        {
            _appdbcontext.ViajeClientes.Add(vc);
            await _appdbcontext.SaveChangesAsync();

            return CreatedAtAction("GetViajeCliente", new { id = vc.Id_ViajeClientes }, vc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutViajeCliente(int id, ViajeClientes vc)
        {
            if(id != vc.Id_ViajeClientes)
            {
                return BadRequest();
            }

            _appdbcontext.Entry(vc).State = EntityState.Modified;

            try
            {
                await _appdbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!ViajeClienteExists(id))
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
        public async Task<IActionResult> DeleteViajesClientes(int id)
        {
            var vc = await _appdbcontext.ViajeClientes.FindAsync(id);
            if(vc  == null)
            {
                return NotFound();
            }

            _appdbcontext.ViajeClientes.Remove(vc);
            await _appdbcontext.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajeClienteExists(int id)
        {
            return _appdbcontext.ViajeClientes.Any(e => e.Id_ViajeClientes == id);
        }

    }
}
