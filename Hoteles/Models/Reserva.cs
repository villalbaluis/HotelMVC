using Foolproof;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hoteles.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Index("IndexNombre", IsUnique = true)]
        [DisplayName("Nombre Reserva")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha Inicio")]
        public DateTime Fecha_Inicio { get; set; }

        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha Fin")]
        public DateTime Fecha_Fin { get; set; }

        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        public bool Estado { get; set; }

        public int IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }

}