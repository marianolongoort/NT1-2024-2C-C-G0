namespace Estacionamiento_C.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }

        public Persona Persona { get; set; }
    }
}
