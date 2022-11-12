using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models 
{
    public class Paciente {
        [Key]
        public int IdPaciente { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [Display(Prompt = "Ingrese un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        [Display(Prompt = "Ingrese un apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe ingresar un DNI")]
        [Display(Name = "DNI", Prompt = "Ingrese un DNI")]
        public string Dni { get; set; }

        [Display(Name = "Teléfono", Prompt = "Ingrese un Teléfono")]
        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "Debe ingresar un email")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email válido")]
        [Display(Name = "Email", Prompt = "Ingrese un email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Debe ingresar una dirección")]
        [Display(Name = "Dirección", Prompt = "Ingrese una Dirección")]
        public string Direccion { get; set; }

        public List<Turno> Turno { get; set; }
        
    }
}