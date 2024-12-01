using back_Lozgar.DTO;
using back_Lozgar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_Lozgar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly appDBcontext _appdbcontext;

        public BoletoController(appDBcontext appDBcontext)
        {
            _appdbcontext = appDBcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoletosCliente>>> GetViajes()
        {
            var viajes = await _appdbcontext.ViajesDisponible
                .Join(_appdbcontext.ViajeClientes,
                    v => v.id_ViajeDisponible,
                    vc => vc.id_ViajeDisponible,
            (v, vc) => new { v, vc })
                .Join(_appdbcontext.Cliente,
                    vvc => vvc.vc.Id_Cliente,
                    p => p.Id_Cliente,
                    (vvc, p) => new BoletosCliente
                    {
                        IdViajesDisponible = vvc.v.id_ViajeDisponible,
                        OrigenCuidad = vvc.v.origen_cuidad,
                        DestinoCuidad = vvc.v.destino_cuidad,
                        Precio = vvc.v.precio,
                        DescripcionViaje = vvc.v.descripcion,
                        HoraSalida = vvc.v.HoraSalida,
                        HoraLlegada = vvc.v.HoraLlegada,
                        IdPasajero = p.Id_Cliente,
                        NombrePasajero = p.Nombre_pasajero,
                        TelefonoPasajero = p.telefono_pasajero,
                        DiaViaje = p.diaViaje
                    })
                .ToListAsync();

            return Ok(viajes);
        }
    }
}
