using System.ComponentModel.DataAnnotations;

namespace Turnos.Models 
{
    public class Paciente {
        [Key]
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        
    }
}