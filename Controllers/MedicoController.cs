using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;
using Turnos.ViewModel;
namespace Turnos.Controllers
{
    [Authorize]
    public class MedicoController : Controller
    {
        private readonly TurnosContext _context;

        public MedicoController(TurnosContext context)
        {
            _context = context;
        }

        // GET: Medico
        [AllowAnonymous]
        public async Task<IActionResult> Index(string busquedaNombre, int? busquedaEspecialidad, int pagina = 1)
        {
            paginador paginador = new paginador(){
                pagActual = pagina,
                regXpag = 3,
            };

            var consulta = _context.Medico.Include(m => m.MedicoEspecialidad).ThenInclude(m => m.Especialidad).Select(m => m);
            if (!String.IsNullOrEmpty(busquedaNombre))
            {
                consulta = consulta.Where(m => m.Nombre.Contains(busquedaNombre));
            }

            if (busquedaEspecialidad.HasValue)
            {
                consulta = consulta.Where(m => m.MedicoEspecialidad.Any(me => me.IdEspecialidad == busquedaEspecialidad));
            }

            paginador.cantReg = consulta.Count();
            var datosAmostrar = consulta
                .Skip((paginador.pagActual - 1) * paginador.regXpag)
                .Take(paginador.regXpag);
            
            foreach (var item in Request.Query)
            {
                paginador.ValoresQueryString.Add(item.Key, item.Value);
            }

            MedicoViewModel Datos = new MedicoViewModel(){
                ListaMedicos = await datosAmostrar.ToListAsync(),
                ListaEspecialidades = new SelectList(_context.Especialidad, "IdEspecialidad", "Descripcion", busquedaEspecialidad),
                busquedaEspecialidad = busquedaEspecialidad,
                busquedaNombre = busquedaNombre,
                paginador = paginador
            };
            return View(Datos);        
        }

        // GET: Medico/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .Where(m => m.IdMedico == id)
                .Include(m => m.MedicoEspecialidad)
                .ThenInclude(m => m.Especialidad)
                .FirstOrDefaultAsync();
                
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // GET: Medico/Create
        public IActionResult Create()
        {
            ViewData["ListaEspecialidades"] = new SelectList(_context.Especialidad, "IdEspecialidad", "Descripcion");
            return View();
        }

        // POST: Medico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedico,Nombre,Apellido,Matricula,Telefono,Email,Direccion,Localidad,HorarioEntrada,HorarioSalida")] Medico medico, int IdEspecialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();

                var medicoEspecialidad = new MedicoEspecialidad();
                medicoEspecialidad.IdMedico = medico.IdMedico;
                medicoEspecialidad.IdEspecialidad = IdEspecialidad;
                _context.Add(medicoEspecialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        // GET: Medico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
            .Where(m => m.IdMedico == id)
            .Include(me => me.MedicoEspecialidad)
            .FirstOrDefaultAsync();

            
            if (medico == null)
            {
                return NotFound();
            }

            ViewData["ListaEspecialidades"] = new SelectList(_context.Especialidad, "IdEspecialidad", "Descripcion", medico.MedicoEspecialidad[0].IdEspecialidad);
            return View(medico);
        }

        // POST: Medico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,Nombre,Apellido,Matricula,Telefono,Email,Direccion,Localidad,HorarioEntrada,HorarioSalida")] Medico medico, int IdEspecialidad)
        {
            if (id != medico.IdMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                    var medicoEspecialidad = await _context.MedicoEspecialidad.FirstOrDefaultAsync(me => me.IdMedico == id);
                    _context.Remove(medicoEspecialidad);
                    await _context.SaveChangesAsync();

                    medicoEspecialidad.IdEspecialidad = IdEspecialidad;

                    _context.Add(medicoEspecialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.IdMedico))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        // GET: Medico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: Medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicoEspecialidad = await _context.MedicoEspecialidad.FirstOrDefaultAsync(me => me.IdMedico == id);

            _context.MedicoEspecialidad.Remove(medicoEspecialidad);
            await _context.SaveChangesAsync();

            var medico = await _context.Medico.FindAsync(id);
            _context.Medico.Remove(medico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoExists(int id)
        {
            return _context.Medico.Any(e => e.IdMedico == id);
        }
        [AllowAnonymous]
        public string TraerHorarioAtencionDesde(int idMedico){
            var horarioAtencionDesde = _context.Medico.Where(m => m.IdMedico == idMedico).FirstOrDefault().HorarioEntrada;
            return horarioAtencionDesde.Hour + ":" + horarioAtencionDesde.Minute;
        }
        [AllowAnonymous]
        public string TraerHorarioAtencionHasta(int idMedico)
        {
            var horarioAtencionHasta = _context.Medico.Where(m => m.IdMedico == idMedico).FirstOrDefault().HorarioSalida;
            return horarioAtencionHasta.Hour + ":" + horarioAtencionHasta.Minute;
        }
    }
}
