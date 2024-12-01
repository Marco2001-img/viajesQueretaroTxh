using back_Lozgar.DTO;
using back_Lozgar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_Lozgar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesDisponiblesController : ControllerBase
    {
        private readonly appDBcontext _appdbcontext;

        public ViajesDisponiblesController(appDBcontext appDBcontext)
        {
            _appdbcontext = appDBcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViajesDisponibles>>> GetViajesDisponibles()
        {
            return await _appdbcontext.ViajesDisponible.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViajesDisponibles>> getViajeDisponible(int id)
        {
            var vd = await _appdbcontext.ViajesDisponible.FindAsync(id);

            if (vd == null)
            {
                return NotFound();
            }

            return vd;
        }

        [HttpPost]
        public async Task<ActionResult<ViajesDisponibles>> PostViajesDisponible(ViajesDisponibles vid)
        {
            _appdbcontext.ViajesDisponible.Add(vid);
            await _appdbcontext.SaveChangesAsync();

            return CreatedAtAction("getViajeDisponible", new { id = vid.id_ViajeDisponible }, vid);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutViajeDisponible(int id, ViajesDisponibles vd)
        {
            if(id != vd.id_ViajeDisponible)
            {
                return BadRequest();
            }

            _appdbcontext.Entry(vd).State = EntityState.Modified;

            try
            {
                await _appdbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!ViajeDisponibleExists(id))
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
        public async Task<IActionResult> DeleteViajeDisponible(int id)
        {
            var Vd = await _appdbcontext.ViajesDisponible.FindAsync(id);
            if(Vd == null)
            {
                return NotFound();
            }

            _appdbcontext.ViajesDisponible.Remove(Vd);
            await _appdbcontext.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajeDisponibleExists(int id)
        {
            return _appdbcontext.ViajesDisponible.Any(e => e.id_ViajeDisponible == id);
        }

    }
}
