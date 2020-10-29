using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace animetflix.Models.DTOs
{
    public class SerieDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        [MinLength(3, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres")]
        public string Nombre { get; set; }
        
        public int Anio { get; set; }

        [StringLength(500, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        public string Sinopsis { get; set; }

        public string Trailer { get; set; }
        public string PosterUrl { get; set; }
    }
}
