using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pica.Taller.Mvc.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Dirección de correo")]
        [Required(ErrorMessage ="La dirección de correo es obligatoria")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage ="La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Recordarme?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
