using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_Lozgar.Model
{
    public class ViajesDisponibles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ViajeDisponible { get; set; }

        [Required]
        public string origen_cuidad { get; set; }

        [Required]
        public string destino_cuidad { get; set; }

        [Required]
        public int precio { get; set; }

        [Required]
        public string descripcion { get; set; }

        [Required]
        public string HoraSalida { get; set; }

        [Required]
        public string HoraLlegada { get; set; }
    }
}
