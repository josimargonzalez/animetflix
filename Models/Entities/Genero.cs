using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace animetflix.Models.Entities
{
    public class Genero
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(3, ErrorMessage = "El campo {0} debe tener al menos 3 caracteres")]
        public string Nombre { get; set; }
    }
}
