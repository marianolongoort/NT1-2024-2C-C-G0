﻿// <auto-generated />
using System;
using Estacionamiento_C.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Estacionamiento_C.Migrations
{
    [DbContext(typeof(EstacionamientoDb))]
    [Migration("20241009223316_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Estacionamiento_C.Models.ClienteVehiculo", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "VehiculoId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("ClientesVehiculos");
                });

            modelBuilder.Entity("Estacionamiento_C.Models.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId")
                        .IsUnique();

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("Estacionamiento_C.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly>("Hora")
                        .HasColumnType("time");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator().HasValue("Persona");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Estacionamiento_C.Models.Telefono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("TipoTelefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("Estacionamiento_C.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Patente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Estacionamiento_C.Models.Cliente", b =>
                {
                    b.HasBaseType("Estacionamiento_C.Models.Persona");

                    b.Property<long>("NumeroContribuyente")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Estacionamiento_C.Models.ClienteVehiculo", b =>
                {
                    b.HasOne("Estacionamiento_C.Models.Cliente", "Cliente")
                        .WithMany("ClientesVehiculos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Estacionamiento_C.Models.Vehiculo", "Vehiculo")
                        .WithMany("ClientesVehiculos")
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Estacionamiento_C.Models.Direccion", b =>
                {
                    b.HasOne("Estacionamiento_C.Models.Persona", "Persona")
                        .WithOne("Direccion")
                        .HasForeignKey("Estacionamiento_C.Models.Direccion", "PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Estacionamiento_C.Models.Telefono", b =>
                {
                    b.HasOne("Estacionamiento_C.Models.Cliente", "Cliente")
                        .WithMany("Telefonos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Estacionamiento_C.Models.Persona", b =>
                {
                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("Estacionamiento_C.Models.Vehiculo", b =>
                {
                    b.Navigation("ClientesVehiculos");
                });

            modelBuilder.Entity("Estacionamiento_C.Models.Cliente", b =>
                {
                    b.Navigation("ClientesVehiculos");

                    b.Navigation("Telefonos");
                });
#pragma warning restore 612, 618
        }
    }
}
