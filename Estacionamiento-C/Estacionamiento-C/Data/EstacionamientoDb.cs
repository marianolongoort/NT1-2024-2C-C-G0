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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Test>().HasKey(t => t.Identificador);

            modelBuilder.Entity<ClienteVehiculo>().HasKey(cv => new { cv.ClienteId,cv.VehiculoId});

            modelBuilder.Entity<ClienteVehiculo>()
                                    .HasOne(cv => cv.Cliente)
                                        .WithMany(c => c.ClientesVehiculos)
                                    .HasForeignKey(cv => cv.ClienteId);

            modelBuilder.Entity<ClienteVehiculo>()
                                    .HasOne(cv => cv.Vehiculo)
                                        .WithMany(v => v.ClientesVehiculos)
                                    .HasForeignKey(cv => cv.VehiculoId);
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Estacionamiento_C.Models.ClienteVehiculo> ClienteVehiculo { get; set; }
        public DbSet<Estacionamiento_C.Models.Vehiculo> Vehiculo { get; set; }
    }
}
