using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hoteles.Models
{
    public class Hotel
    {
        [Key]
        public int IdHotel { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(45, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Index("IndexNombre", IsUnique = true)]
        [DisplayName("Hotel")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [DisplayName("Ubicación del hotel")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Cantidad de habitaciones")]
        public int Cantidad_Habitacion { get; set; }

        public virtual ICollection<Habitacion> Habitaciones { get; set; }
    }
}