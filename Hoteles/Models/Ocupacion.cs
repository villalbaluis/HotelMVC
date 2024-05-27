using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hoteles.Models
{
    public class Ocupacion
    {
        [Key]
        public int IdOcupacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [DisplayName("Descripción de la ocupación")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int IdHabitacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int IdUsuario { get; set; }

        public virtual Habitacion Habitacion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }

}