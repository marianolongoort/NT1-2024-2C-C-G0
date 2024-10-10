using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_C.Models.Viewmodels
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; } = false;

    }
}
