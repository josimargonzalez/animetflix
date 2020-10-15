using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animetflix.Models.Entities;
using animetflix.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace animetflix.Controllers
{
    public class GenerosController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var listaGeneros = await context.Generos.OrderBy(a => a.Nombre).ToListAsync();
            var listaDTO = mapper.Map<List<GeneroDTO>>(listaGeneros);

            return View(listaDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] GeneroCreacionDTO genero )
        {
            //Valida si las reglas del modelo se cumplen o no
            if (ModelState.IsValid)
            {
                var generoDB = mapper.Map<Genero>(genero);
                
                context.Add(generoDB);
                await context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(genero);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var genero = await context.Generos.FindAsync(id);
            var generoDTO = mapper.Map<GeneroDTO>(genero);
            
            return View(generoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] GeneroDTO genero )
        {
            //Valida si las reglas del modelo se cumplen o no
            if (ModelState.IsValid)
            {
                var generoDB = mapper.Map<Genero>(genero);
                generoDB.Id = id;
                context.Update(generoDB);
                await context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(genero);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var genero = await context.Generos.FindAsync(id);
            var generoDTO = mapper.Map<GeneroDTO>(genero);
            
            return View(generoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, [Bind("Id,Nombre")] GeneroDTO genero )
        {
            var generoDB = mapper.Map<Genero>(genero);
            generoDB.Id = id;
            context.Remove(generoDB);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}