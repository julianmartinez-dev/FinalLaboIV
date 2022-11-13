using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;
using Turnos.ViewModel;

namespace Turnos.Controllers
{
    [Authorize]
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            paginador paginador = new paginador()
            {
                cantReg = _context.Especialidad.Count(),
                pagActual = pagina,
                regXpag = 3
            };
            ViewData["paginador"] = paginador;
            
            var datosAmostrar = _context.Especialidad
                .Skip((pagina - 1) * paginador.regXpag)
                .Take(paginador.regXpag);

            return View(await datosAmostrar.ToListAsync());
            // return View(await _context.Especialidad.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.FindAsync(id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad, Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(especialidad);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.FirstOrDefaultAsync(m => m.IdEspecialidad == id);

            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id){
            var especialidad = await _context.Especialidad.FindAsync(id);
            _context.Especialidad.Remove(especialidad);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEspecialidad, Descripcion")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(especialidad);
        }
    }
}