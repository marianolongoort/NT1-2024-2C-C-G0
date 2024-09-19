using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamiento_C.Models
{
    public class Persona
    {
        private const string _requiredMsg = "El campo {0} es requerido";

        public int Id { get; set; }

        [Required(ErrorMessage = _requiredMsg)]
        [StringLength(200, MinimumLength = 5,ErrorMessage = "El campo {0} debe estar entre {2} y {1}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = _requiredMsg)]
        [MinLength(5,ErrorMessage = "El campo {0} debe ser superior a {1}")]
        [MaxLength(200,ErrorMessage = "El campo {0} debe ser menor a {1}")]
        public string Apellido { get; set; }

        
        [EmailAddress]
        [Required(ErrorMessage = _requiredMsg)]
        [Display(Name ="Correo")]
        public string Email { get; set; }



        //Propiedad Navegacional
        public Direccion Direccion { get; set; }


        [Range(1000000,99999999,ErrorMessage = "El campo DNI debe estar entre 1000000 y 99999999")]
        public int Dni { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Date)]
        public DateOnly Fecha { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly Hora { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [NotMapped]
        public int Edad { get; }

        [NotMapped]
        public string   NombreCompleto { 
            get {
                return $"{Nombre}, {Apellido}";
            
            }
        }
    }
}
