using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{   
    public class Especialidad {
        [Key]
        public int IdEspecialidad { get; set; }
        [StringLength(50, ErrorMessage = "El nombre de la especialidad no puede superar los 50 caracteres")]
        [Required (ErrorMessage = "Debe ingresar una descripcion")]
        [Display(Name = "Descripción", Prompt = "Ingrese una Descripción")]
        public string Descripcion { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}