﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdministracionCRUD.Models;

namespace AdministracionCRUD.Controllers
{
    public class EquipoesController : Controller
    {
        private readonly DbcreativaContext _context;

        public EquipoesController(DbcreativaContext context)
        {
            _context = context;
        }

        // GET: Equipoes
        public async Task<IActionResult> Index(string buscar)
        {
            var equipos_encontrados = from equipos in _context.Equipos.Include(p => p.IdMarcaNavigation) select equipos;
            if (!String.IsNullOrEmpty(buscar))
            {
                equipos_encontrados = equipos_encontrados.Where(item => item.Nombre!.Contains(buscar));
            }
            return View(await equipos_encontrados.ToListAsync());
        }

        // GET: Equipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipos == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .Include(e => e.IdMarcaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }
        
        // GET: Equipoes/Create
        public IActionResult Create()
        {
            List<Marca> marcas = _context.Marcas.ToList();
            List<SelectListItem> selectListItems = marcas.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Nombre
            }).ToList();

            ViewData["IdMarca"] = selectListItems;

            return View();
        }


        // POST: Equipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdMarca,Nombre,Serie,Tipo,Descripcion")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id", equipo.IdMarca);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipos == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id", equipo.IdMarca);
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdMarca,Nombre,Serie,Tipo,Descripcion")] Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
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
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id", equipo.IdMarca);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipos == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .Include(e => e.IdMarcaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipos == null)
            {
                return Problem("Entity set 'DbcreativaContext.Equipos'  is null.");
            }
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo != null)
            {
                _context.Equipos.Remove(equipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
          return (_context.Equipos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
