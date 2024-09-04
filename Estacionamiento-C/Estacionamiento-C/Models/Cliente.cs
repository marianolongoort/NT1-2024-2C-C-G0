using System.Collections.Generic;

namespace Estacionamiento_C.Models
{
    public class Cliente : Persona
    {
        public int NumeroContribuyente { get; set; } //CUIT CUIL


        public List<ClienteVehiculo> ClientesVehiculos { get; set; }


        //Prop Navegacional
        public List<Telefono> Telefonos { get; set; }
    }
}
