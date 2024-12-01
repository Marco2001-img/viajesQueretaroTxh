using back_Lozgar.Model;
using Microsoft.EntityFrameworkCore;

namespace back_Lozgar.DTO
{
    public class appDBcontext : DbContext
    {
        public appDBcontext(DbContextOptions<appDBcontext> options) : base(options) { }

       public DbSet<Conductor> Conductor { get; set; }
       public DbSet<Cliente> Cliente { get; set; }
       public DbSet<ViajesDisponibles> ViajesDisponible { get; set; }
       
        public DbSet<ViajeClientes> ViajeClientes { get; set; }

        public DbSet<BoletosCliente> Boletos { get; set; }
    }
}
