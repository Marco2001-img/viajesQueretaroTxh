using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_Lozgar.Model
{
    public class Conductor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_conductor { get; set; }

        [Required]
        public string Nombre_conductor { get; set; }
        [Required]
        public string telefono { get; set; }
        [Required]
        public string descripcion { get; set; }

    }
}
