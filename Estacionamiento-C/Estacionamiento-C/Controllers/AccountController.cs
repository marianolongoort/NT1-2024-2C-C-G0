using Estacionamiento_C.Data;
using Estacionamiento_C.Models;
using Estacionamiento_C.Models.Viewmodels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Estacionamiento_C.Controllers
{
    public class AccountController : Controller
    {
        private readonly EstacionamientoDb _midb;
        private readonly UserManager<Persona> _userManager;        
        private readonly SignInManager<Persona> _signInManager;

        public AccountController(
            EstacionamientoDb midb,
            UserManager<Persona> userManager,            
            SignInManager<Persona> signInManager
            )
        {
            this._midb = midb;
            this._userManager = userManager;            
            this._signInManager = signInManager;
        }


        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistroUsuario viewModel)
        {

            if (ModelState.IsValid)
            {
                //queremos registrar
                Cliente clienteNuevo = new Cliente();
                clienteNuevo.Email = viewModel.Email;
                clienteNuevo.UserName = viewModel.Email;

                var resultadCreate = await _userManager.CreateAsync(clienteNuevo, viewModel.Password);

                if (resultadCreate.Succeeded)
                {
                    //si está ok, sigo 
                    await _userManager.AddToRoleAsync(clienteNuevo, "Cliente");
                    //iniciamos sesión con elusuario.
                    await _signInManager.SignInAsync(clienteNuevo, isPersistent: true);

                    //defino a donde lo quiero enviar al usuario.
                    return RedirectToAction("Details", "Clientes", new { id = clienteNuevo.Id });
                }
                //se presento un error lo manejo.
                //ModelState.AddModelError("Password","Password no válida");
                foreach(var error in resultadCreate.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
            }

            return View(viewModel);
        }


        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Models.Viewmodels.Login modelo)
        {

            if (ModelState.IsValid)
            {
                var resultadoInicioSesion = await _signInManager.PasswordSignInAsync(modelo.Email, modelo.Password, modelo.RememberMe, false);

                if (resultadoInicioSesion.Succeeded)
                {

                    if (User.IsInRole("Cliente")) { return RedirectToAction("Index", "Clientes"); }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
            }
            return View(modelo);
        }


    }
}

