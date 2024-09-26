using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estacionamiento_C.Data;
using Estacionamiento_C.Models;

namespace Estacionamiento_C.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly EstacionamientoDb _miDb;

        public DireccionesController(EstacionamientoDb context)
        {
            _miDb = context;
        }

        public async Task<IActionResult> Index()
        {
            var estacionamientoDb = _miDb.Direcciones.Include(d => d.Persona);
            return View(await estacionamientoDb.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones
                .Include(d => d.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        
        public IActionResult Create()
        {
            var personasEnDb = _miDb.Personas
                                        .Include(p => p.Direccion)
                                        .Where(p => p.Direccion == null);

            ViewData["PersonaId"] = new SelectList(personasEnDb, "Id", "NombreCompleto");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Calle,Numero,PersonaId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _miDb.Direcciones.Add(direccion);
                _miDb.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["PersonaId"] = new SelectList(_miDb.Personas, "Id", "NombreCompleto", direccion.PersonaId);
            return View(direccion);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion =  _miDb.Direcciones.Find(id);
            var direccion2 = _miDb.Direcciones.FirstOrDefault(direccionItem => direccionItem.Id == id);
            var direcciones = _miDb.Direcciones.Where(direccionItem => direccionItem.Calle == "Cordboa");
            
            if (direccion == null)
            {
                return NotFound();
            }
            ViewData["PersonaId"] = new SelectList(_miDb.Personas, "Id", "NombreCompleto", direccion.PersonaId);
            return View(direccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle,Numero,PersonaId")] Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Direcciones.Update(direccion);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionExists(direccion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaId"] = new SelectList(_miDb.Personas, "Id", "NombreCompleto", direccion.PersonaId);
            return View(direccion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones
                .Include(d => d.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccion = await _miDb.Direcciones.FindAsync(id);
            if (direccion != null)
            {
                _miDb.Direcciones.Remove(direccion);
            }

            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionExists(int id)
        {
            return _miDb.Direcciones.Any(e => e.Id == id);
        }
    }
}
