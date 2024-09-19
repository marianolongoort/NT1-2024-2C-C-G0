using Estacionamiento_C.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Estacionamiento_C.Data
{
    public class EstacionamientoDb : DbContext
    {
        public EstacionamientoDb(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
    }
}
