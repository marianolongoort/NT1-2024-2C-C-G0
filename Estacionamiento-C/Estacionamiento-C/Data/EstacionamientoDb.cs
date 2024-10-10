using Estacionamiento_C.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System.Collections.Generic;

namespace Estacionamiento_C.Data
{
    public class EstacionamientoDb : IdentityDbContext<IdentityUser<int>,IdentityRole<int>,int>
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

            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");
            //modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<ClienteVehiculo> ClientesVehiculos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Rol> Roles { get; set; }
    }
}
