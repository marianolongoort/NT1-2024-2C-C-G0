using Estacionamiento_C.Data;
using Estacionamiento_C.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamiento_C.Controllers
{
    public class TestController : Controller
    {
        private readonly EstacionamientoDb _midb;

        public TestController(EstacionamientoDb midb)
        {
            this._midb = midb;
        }

        public IActionResult Index()
        {
            var personasEnDb0 = _midb.Personas;
            List<Persona> personasEnDb = _midb.Personas.ToList();

            return View(personasEnDb);
        }


    }

}
