using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animetflix.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace animetflix.Controllers
{
    public class GenerosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenerosController(ApplicationDbContext context)
        {
            _context = context;    
        }
        public async Task<IActionResult> Index()
        {
            var listaGeneros = await _context.Generos.OrderBy(a => a.Nombre).ToListAsync();
            return View(listaGeneros);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Genero genero )
        {
            //Valida si las reglas del modelo se cumplen o no
            if (ModelState.IsValid)
            {
                _context.Add(genero);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(genero);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            
            return View(genero);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Genero genero )
        {
            //Valida si las reglas del modelo se cumplen o no
            if (ModelState.IsValid)
            {
                _context.Update(genero);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(genero);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            
            return View(genero);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, [Bind("Id,Nombre")] Genero genero )
        {
            _context.Remove(genero);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}