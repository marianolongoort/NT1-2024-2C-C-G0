namespace Estacionamiento_C.Models
{
    public class Telefono
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public TipoTelefono TipoTelefono { get; set; }
        
        //Prop Navegacional
        public Cliente Cliente { get; set; }
        
        //Prop realacional
        public int ClienteId { get; set; }

    }
}
