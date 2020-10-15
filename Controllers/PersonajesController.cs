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
    public class PersonajesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PersonajesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var listaPersonajes = await context.Personajes.OrderBy(a => a.Nombre).ToListAsync();
            var listaDTO = mapper.Map<List<PersonajeDTO>>(listaPersonajes);

            return View(listaDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] PersonajeCreacionDTO personaje )
        {
            //Valida si las reglas del modelo se cumplen o no
            if (ModelState.IsValid)
            {
                var personajeDB = mapper.Map<Personaje>(personaje);
                
                context.Add(personajeDB);
                await context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(personaje);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var personaje = await context.Personajes.FindAsync(id);
            var personajeDTO = mapper.Map<PersonajeDTO>(personaje);
            
            return View(personajeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] PersonajeDTO personaje )
        {
            //Valida si las reglas del modelo se cumplen o no
            if (ModelState.IsValid)
            {
                var personajeDB = mapper.Map<Personaje>(personaje);
                personajeDB.Id = id;
                context.Update(personajeDB);
                await context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(personaje);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var personaje = await context.Personajes.FindAsync(id);
            var personajeDTO = mapper.Map<PersonajeDTO>(personaje);
            
            return View(personajeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, [Bind("Id,Nombre")] PersonajeDTO personaje )
        {
            var personajeDB = mapper.Map<Personaje>(personaje);
            personajeDB.Id = id;
            context.Remove(personajeDB);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}