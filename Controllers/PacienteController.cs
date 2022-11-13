using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;
using Turnos.ViewModel;

namespace Turnos.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private readonly TurnosContext _context;
        private readonly IWebHostEnvironment env;
        public PacienteController(TurnosContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int pagina=1)
        {
            paginador paginador = new paginador()
            {
                cantReg = _context.Paciente.Count(),
                pagActual = pagina,
                regXpag = 3
            };
            ViewData["paginador"] = paginador;

            var datosAmostrar = _context.Paciente
                .Skip((paginador.pagActual - 1) * paginador.regXpag)
                .Take(paginador.regXpag);
            return View(await datosAmostrar.ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaciente,Nombre,Apellido,Dni,Telefono,Email,Direccion")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("IdPaciente,Nombre,Apellido,Dni,Telefono,Email,Direccion")] Paciente paciente)
        {
            if (id != paciente.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var paciente = await _context.Paciente.FindAsync(id);
            if(paciente == null)
            {
                return NotFound();
            }
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Importar(){
            var archivos = HttpContext.Request.Form.Files;
            if(archivos != null && archivos.Count > 0){
                var archivo = archivos[0];
                var pathDestino = Path.Combine(env.WebRootPath, "importaciones");

                if(archivo.Length > 0){
                   var archivoDestino = Guid.NewGuid().ToString().Replace("-","") + Path.GetExtension(archivo.FileName);
                   string pathcompleto = Path.Combine(pathDestino, archivoDestino);
                   using(var filestream = new FileStream(pathcompleto, FileMode.Create)){
                       archivo.CopyTo(filestream);
                   }

                   using(var file = new FileStream(pathcompleto, FileMode.Open)){
                        List<string> renglones = new List<string>();
                        List<Paciente> pacientesArchivo = new List<Paciente>();

                        StreamReader fileContent = new StreamReader(file);

                        do{
                            renglones.Add(fileContent.ReadLine());
                        }while(!fileContent.EndOfStream);

                        foreach(string renglon in renglones){
                            string[] datos = renglon.Split(";");
                            
                           Paciente pacienteTemp = new Paciente(){
                                 Nombre = datos[0],
                                 Apellido = datos[1],
                                 Dni = datos[2],
                                 Telefono = datos[3],
                                 Email = datos[4],
                                 Direccion = datos[5]
                            };
                            pacientesArchivo.Add(pacienteTemp);
                           }
                        if (pacientesArchivo.Count > 0)
                        {
                            _context.AddRange(pacientesArchivo);
                            _context.SaveChanges();
                        }
                        ViewBag.cantReng = pacientesArchivo.Count + " de " + renglones.Count;
                    }
                      
                   }
                }
            return View();
            }

        }

}
