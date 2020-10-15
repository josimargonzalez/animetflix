using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace animetflix.Models.DTOs
{
    public class PersonajeCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        [MinLength(3, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres")]
        public string Nombre { get; set; }
        
        public DateTime FechaNacimiento { get; set; }

        [StringLength(500, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        public string Biografia { get; set; }

        public string Foto { get; set; }
    }
}
