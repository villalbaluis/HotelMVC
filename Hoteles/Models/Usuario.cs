using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hoteles.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Index("IndexNombre", IsUnique = true)]
        [DisplayName("Nombre Usuario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(3000000000, 3999999999, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [DisplayName("Nombre Telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [EmailAddress(ErrorMessage = "Favor ingresar un correo valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        public string Password { get; set; }

        //Llave foranea para la relacion con Rol
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        public int IdRol { get; set; }

        public virtual ICollection<Rol> Roles { get; set; }

        //Propiedad navigacional para la relacion con Reservas
        public virtual ICollection<Reserva> Reservas { get; set; }

        //Propiedad navigacional para la relacion con Ocupaciones
        public virtual ICollection<Ocupacion> Ocupaciones { get; set; }

    }
}