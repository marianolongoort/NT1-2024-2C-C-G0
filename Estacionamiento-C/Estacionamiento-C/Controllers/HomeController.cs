using Estacionamiento_C.Data;
using Estacionamiento_C.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace Estacionamiento_C.Controllers
{
    public class HomeController : Controller
    {
        private readonly EstacionamientoDb _midb;

        public HomeController(EstacionamientoDb midb)
        {
            this._midb = midb;
        }

        public ActionResult Index()
        {
            var personas = _midb.Personas.ToList();

            ViewResult resultado = View(personas);
            return resultado;
        }

        public ActionResult Privacy(bool getnombre = false)
        {
            if (getnombre)
            {
                return View("GetNombre");
            }
            
            return View();
        }

        public int Sumar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public ActionResult GetNombre(string parametro = "No definido")
        {
            return View(model:parametro);
        }
    }
}
