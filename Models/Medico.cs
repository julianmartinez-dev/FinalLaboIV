using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un apellido")] 
        public string Apellido { get; set; }
        [Required (ErrorMessage = "Debe ingresar un matricula")]
        public string Matricula { get; set; }
        [Display(Name = "Teléfono", Prompt = "Ingrese un Teléfono")]
        [Required (ErrorMessage = "Debe ingresar un teléfono")]
        public string Telefono { get; set; }
        [Required (ErrorMessage = "Debe ingresar un email")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email válido")]
        public string Email { get; set; }
        [Display(Name = "Dirección", Prompt = "Ingrese una Dirección")]
        [Required (ErrorMessage = "Debe ingresar una dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Debe ingresar una localidad")]
        public string Localidad { get; set; }
        [Display(Name = "Horario de entrada")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioEntrada { get; set; }
        [Display(Name = "Horario de salida")]
        [DataType(DataType.Time)]
        [DisplayFormat (DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioSalida { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public List<Turno> Turno { get; set; }

    }
}