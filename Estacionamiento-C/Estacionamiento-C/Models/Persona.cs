using System;
using System.Collections.Generic;

namespace Estacionamiento_C.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }
        //Propiedad Navegacional
        public Direccion Direccion { get; set; }        

    }
}
