using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hoteles.Models
{
    public class Habitacion
    {
        [Key]
        public int IdHabitacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Index("IndexNombre", IsUnique = true)]
        [DisplayName("Habitación")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Capacidad")]
        public int Capacidad_Habitacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Tarifa por noche")]
        public decimal Tarifa_Noche { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayName("Disponibilidad")]
        public bool Disponible { get; set; }

        //Llave foranea para la relacion con Hotel
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        public int IdHotel { get; set; }

        //Propiedad navigacional para la relacion con Hotel
        public virtual Hotel Hotel { get; set; }

        //Propiedad navigacional para la relacion con Ocupaciones
        public virtual ICollection<Ocupacion> Ocupaciones { get; set; }
    }
}