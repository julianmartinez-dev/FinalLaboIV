using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Turnos.Models;

namespace Turnos.ViewModel
{

    public class MedicoViewModel{
        public List<Medico> ListaMedicos { get; set; }
        public SelectList ListaEspecialidades { get; set; }

        public int? busquedaEspecialidad { get; set; }
        public string busquedaNombre { get; set; }
        public paginador paginador { get; set; }
    }
    public class paginador
    {
        public int cantReg { get; set; }
        public int regXpag { get; set; }
        public int pagActual { get; set; }
        public int totalPag => (int)Math.Ceiling((decimal)cantReg / regXpag);
        public Dictionary<string, string> ValoresQueryString { get; set; } = new Dictionary<string, string>();
    }
}