using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_Lozgar.Model
{
    public class ViajeClientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_ViajeClientes { get; set; }

        public int Id_Cliente { get; set; }
        public int id_conductor { get; set; }
        public int id_ViajeDisponible { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Cliente clientes { get; set; }

        [ForeignKey("id_conductor")]
        public virtual Conductor conductores { get; set; }

        [ForeignKey("id_ViajeDisponible")]
        public virtual ViajesDisponibles viajesdisponibles { get; set; }
    }
}
