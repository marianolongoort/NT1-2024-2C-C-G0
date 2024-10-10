using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_C.Models.Viewmodels
{
    public class RegistroUsuario
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Ingresa bien la pass")]
        public string ConfirmacionPassword { get; set; }
    }
}
