using Estacionamiento_C.Data;
using Estacionamiento_C.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Estacionamiento_C.Controllers
{
    public class PrecargaController : Controller
    {
        private readonly EstacionamientoDb _midb;
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly SignInManager<Persona> _signInManager;

        public PrecargaController(
            EstacionamientoDb midb,
            UserManager<Persona> userManager,
            RoleManager<Rol> roleManager,
            SignInManager<Persona> signInManager
            )
        {
            this._midb = midb;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }


        public IActionResult Seed()
        {
            //Crear roles
            CrearRoles().Wait();
            //Crear cliente
            CrearClientes().Wait();
            //Crear direccion
            CrearDirecciones();


            return RedirectToAction("Index","Clientes");
        }

        private void CrearDirecciones()
        {
           
        }

        private async Task CrearClientes()
        {
            Cliente cliente = new Cliente()
            {
                Nombre = "Pablo",
                Apellido = "Marmol",
                Dni = 22333444,
                FechaNacimiento = new DateTime(1977, 08, 08),
                Email = "pablo@ort.edu.ar",
                UserName = "pablo@ort.edu.ar",
                Fecha = new DateOnly(1978, 09, 09),
                Hora = new TimeOnly(22, 15),
                NumeroContribuyente = 20223334440
            };

            var resultadoCreate1 = await _userManager.CreateAsync(cliente,"Password1!");

            if (resultadoCreate1.Succeeded)
            {
                //agregarle el rol
                await _userManager.AddToRoleAsync(cliente,"Cliente");
            }

        }

        private async Task CrearRoles()
        {
            await _roleManager.CreateAsync(new Rol("Cliente"));
            await _roleManager.CreateAsync(new Rol("Administrador"));
            await _roleManager.CreateAsync(new Rol("Empleado"));
        }
    }
}
