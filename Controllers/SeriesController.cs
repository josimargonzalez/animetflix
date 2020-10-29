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
    public class SeriesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly LocalFileStorage storage;
        private readonly string Contenedor = "Series";

        public SeriesController(ApplicationDbContext context, IMapper mapper, LocalFileStorage storage)
        {
            this.context = context;
            this.mapper = mapper;
            this.storage = storage;
        }
        public async Task<IActionResult> Index()
        {
            var listaSeries = await context.Series.OrderBy(a => a.Nombre).ToListAsync();
            var listaDTO = mapper.Map<List<SerieDTO>>(listaSeries);

            return View(listaDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SerieCreacionDTO serie )
        {
            //Valida si las reglas del modelo se cumplen o no
            if (ModelState.IsValid)
            {
                var serieDB = mapper.Map<Serie>(serie);

                if (serie.PosterUrl != null)
                {
                    using var memoryStream = new MemoryStream();
                    await serie.PosterUrl.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(serie.PosterUrl.FileName);
                    serieDB.PosterUrl = await storage.SaveFile(contenido, extension, Contenedor, serie.PosterUrl.ContentType);
                }
                
                context.Add(serieDB);
                await context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(serie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serie = await context.Series.FindAsync(id);
            var serieEdicionDTO = mapper.Map<SerieEdicionDTO>(serie);
            
            return View(serieEdicionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] SerieEdicionDTO serie )
        {
            //Valida si las reglas del modelo se cumplen o no
            if (ModelState.IsValid)
            {
                var serieDB = mapper.Map<Serie>(serie);

                if (serie.PosterUrl != null)
                {
                    await storage.DeleteFile(serie.Poster, Contenedor);

                    using var memoryStream = new MemoryStream();
                    await serie.PosterUrl.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(serie.PosterUrl.FileName);
                    serieDB.PosterUrl = await storage.SaveFile(contenido, extension, Contenedor, serie.PosterUrl.ContentType);
                }

                serieDB.Id = id;
                context.Update(serieDB);
                await context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(serie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var serie = await context.Series.FindAsync(id);
            var serieDTO = mapper.Map<SerieDTO>(serie);
            
            return View(serieDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, [Bind("Id,Nombre")] SerieDTO serie )
        {
            var serieDB = mapper.Map<Serie>(serie);
            serieDB.Id = id;
            context.Remove(serieDB);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}