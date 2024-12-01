using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_Lozgar.Model
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Cliente { get; set; }

        [Required]
        public string Nombre_pasajero { get; set; }

        [Required]
        public string telefono_pasajero { get; set; }

        [Required]
        public DateTime diaViaje { get; set; }

        [Required]
        public int NumeroPasajeros { get; set; }

    }
}
