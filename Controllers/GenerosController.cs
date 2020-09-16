using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var listaGeneros = await _context.Generos.ToListAsync();
            return View(listaGeneros);
        }
    }
}