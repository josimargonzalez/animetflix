using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animetflix.Models.Entities;
using animetflix.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using animetflix.Services;
using System.IO;

namespace animetflix.Controllers
{
    public class PersonajesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly LocalFileStorage storage;
        private readonly string Contenedor = "Personajes";

        public PersonajesController(ApplicationDbContext context, IMapper mapper, LocalFileStorage storage)
        {
            this.context = context;
            this.mapper = mapper;
            this.storage = storage;
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
        public async Task<IActionResult> Create([FromForm] PersonajeCreacionDTO personaje )
        {
            //Valida si las reglas del modelo se cumplen o no
            if (ModelState.IsValid)
            {
                var personajeDB = mapper.Map<Personaje>(personaje);

                if (personaje.Foto != null)
                {
                    using var memoryStream = new MemoryStream();
                    await personaje.Foto.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(personaje.Foto.FileName);
                    personajeDB.Foto = await storage.SaveFile(contenido, extension, Contenedor, personaje.Foto.ContentType);
                }
                
                context.Add(personajeDB);
                await context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(personaje);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var personaje = await context.Personajes.FindAsync(id);
            var personajeEdicionDTO = mapper.Map<PersonajeEdicionDTO>(personaje);
            
            return View(personajeEdicionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] PersonajeEdicionDTO personaje )
        {
            //Valida si las reglas del modelo se cumplen o no
            if (ModelState.IsValid)
            {
                var personajeDB = mapper.Map<Personaje>(personaje);

                if (personaje.Foto != null)
                {
                    await storage.DeleteFile(personaje.Imagen, Contenedor);

                    using var memoryStream = new MemoryStream();
                    await personaje.Foto.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(personaje.Foto.FileName);
                    personajeDB.Foto = await storage.SaveFile(contenido, extension, Contenedor, personaje.Foto.ContentType);
                }

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