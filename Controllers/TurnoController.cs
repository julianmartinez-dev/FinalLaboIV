using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Turnos.Models;


namespace Turnos.Controllers
{
    [Authorize]
    public class TurnoController : Controller
    {
        private readonly TurnosContext _context;
        private IConfiguration _configuration;

        public TurnoController(TurnosContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {   
            ViewData["IdMedico" ] = new SelectList((from medico in _context.Medico.OrderBy(p => p.Nombre).ToList() select new { IdMedico = medico.IdMedico, NombreCompleto= medico.Nombre + " " + medico.Apellido}), "IdMedico", "NombreCompleto");

            ViewData["IdPaciente"] = new SelectList((from paciente in _context.Paciente.OrderBy(p => p.Nombre).ToList() select new { IdPaciente = paciente.IdPaciente, NombreCompleto = paciente.Nombre + " " + paciente.Apellido }), "IdPaciente", "NombreCompleto");
            return View();
        }

        [AllowAnonymous]
        public JsonResult ObtenerTurnos(int idMedico){
            var turnos = _context.Turno.Where(t => t.IdMedico == idMedico)
            .Select(t => new { 
                t.IdTurno,
                t.IdMedico,
                t.IdPaciente,
                t.FechaHoraInicio,
                t.FechaHoraFin,
                paciente = t.Paciente.Apellido + ", " + t.Paciente.Nombre
            }).ToList();
            return Json(turnos);
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult GrabarTurno(Turno turno)
        {
            var ok = false;
            try
            {
                _context.Turno.Add(turno);
                _context.SaveChanges();
                ok = true;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Excepcion encontrada.", e);
            }

            var jsonResult = new { ok = ok };
            return Json(jsonResult);
           
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult EliminarTurno(int idTurno)
        {
            var ok = false;
            try
            {
                var turno = _context.Turno.Where(t => t.IdTurno == idTurno).FirstOrDefault();
                if( turno != null){
                    _context.Turno.Remove(turno);
                    _context.SaveChanges();
                    ok = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Excepcion encontrada.", e);
            }

            var jsonResult = new { ok = ok };
            return Json(jsonResult);
        }
    }
}