using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pica.Taller.Mvc.Models
{
    public class ContactViewModel
    {
        [Display(Name = "Dirección de correo")]
        [Required(ErrorMessage ="El correo es necesario para identificar al usuario")]
        [EmailAddress(ErrorMessage ="La direccion de correo no tiene el formato correcto")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Nombre completo")]
        [MaxLength(60, ErrorMessage = "La longitud máxima de la nombre es de 60 carcateres")]
        [Required(ErrorMessage ="El nombre del usuario es requerido")]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(50, ErrorMessage ="La longitud máxima de la dirección es de 50 carcateres")]
        public string Address { get; set; }
    }
}
