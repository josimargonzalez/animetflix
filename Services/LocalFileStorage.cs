using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace animetflix.Services
{
    public class LocalFileStorage
    {
        private readonly IWebHostEnvironment webHost;
        private readonly IHttpContextAccessor accessor;

        public LocalFileStorage(IWebHostEnvironment webHost, IHttpContextAccessor accessor)
        {
            this.webHost = webHost;
            this.accessor = accessor;
        }

        public async Task<string> SaveFile(byte[] contenido, string extension, string contenedor, string contenType)
        {
            var nombreArchivo = $"{Guid.NewGuid()}{extension}";
            var carpeta = Path.Combine(webHost.WebRootPath, contenedor);

            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }

            string ruta = Path.Combine(carpeta, nombreArchivo);

            await File.WriteAllBytesAsync(ruta, contenido);

            var urlActual = $"{accessor.HttpContext.Request.Scheme}://{accessor.HttpContext.Request.Host}";
            var urlBD = Path.Combine(urlActual, contenedor, nombreArchivo).Replace("\\", "/");

            return urlBD;
        }

        public Task DeleteFile(string ruta, string contenedor)
        {
            if (ruta != null)
            {
                var nombreArchivo = Path.GetFileName(ruta);
                string directorio = Path.Combine(webHost.WebRootPath, contenedor, nombreArchivo);

                if (File.Exists(directorio))
                {
                    File.Delete(directorio);
                }
            }

            return Task.FromResult(0);
        }
    }
}
