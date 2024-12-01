using back_Lozgar.DTO;
using back_Lozgar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_Lozgar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        private readonly appDBcontext _appdbcontext;

        public ConductorController(appDBcontext appDBcontext)
        {
            _appdbcontext = appDBcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conductor>>> getConductores()
        {
            return await _appdbcontext.Conductor.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conductor>> GetConductor(int id)
        {
            var conductor = await _appdbcontext.Conductor.FindAsync(id);

            if (conductor == null)
            {
                return NotFound();
            }

            return conductor;
        }

        [HttpPost]
        public async Task<ActionResult<Conductor>> PostConductor(Conductor conductor)
        {
            _appdbcontext.Conductor.Add(conductor);
            await _appdbcontext.SaveChangesAsync();

            return CreatedAtAction("GetConductor", new { id = conductor.id_conductor }, conductor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConductor(int id, Conductor conductor)
        {
            if (id != conductor.id_conductor)
            {
                return BadRequest();
            }
            _appdbcontext.Entry(conductor).State = EntityState.Modified;
            try
            {
                await _appdbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConductorExists(id))
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
        public async Task<IActionResult> DeleteConductor(int id)
        {
            var conductor = await _appdbcontext.Conductor.FindAsync(id);

            if(conductor == null)
            {
                return NotFound();
            }

            _appdbcontext.Conductor.Remove(conductor);
            await _appdbcontext.SaveChangesAsync();

            return NoContent();
        }


        private bool ConductorExists(int id)
        {
            return _appdbcontext.Conductor.Any(e => e.id_conductor == id);
        }

    }
}
