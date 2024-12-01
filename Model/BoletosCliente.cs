using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_Lozgar.Model
{
    public class BoletosCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_boletos { get; set; }
        public int IdViajesDisponible { get; set; }
        public string OrigenCuidad { get; set; }
        public string DestinoCuidad { get; set; }
        public decimal Precio { get; set; }
        public string DescripcionViaje { get; set; }
        public string HoraSalida { get; set; }
        public string HoraLlegada { get; set; }
        public int IdPasajero { get; set; }
        public string NombrePasajero { get; set; }
        public string TelefonoPasajero { get; set; }
        public DateTime DiaViaje { get; set; }
    }
}
