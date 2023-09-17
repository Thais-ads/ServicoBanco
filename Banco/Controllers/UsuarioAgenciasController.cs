using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Banco.Data;
using Banco.Models;

namespace Banco.Controllers
{
    public class UsuarioAgenciasController : Controller
    {
        private readonly BancoContext _context;

        public UsuarioAgenciasController(BancoContext context)
        {
            _context = context;
        }

        // GET: UsuarioAgencias
        public async Task<IActionResult> Index()
        {
              return _context.UsuarioAgencia != null ? 
                          View(await _context.UsuarioAgencia.ToListAsync()) :
                          Problem("Entity set 'BancoContext.UsuarioAgencia'  is null.");
        }

        // GET: UsuarioAgencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuarioAgencia == null)
            {
                return NotFound();
            }

            var usuarioAgencia = await _context.UsuarioAgencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioAgencia == null)
            {
                return NotFound();
            }

            return View(usuarioAgencia);
        }

        // GET: UsuarioAgencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioAgencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Conta,Agencia,permissao")] UsuarioAgencia usuarioAgencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioAgencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioAgencia);
        }

        // GET: UsuarioAgencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuarioAgencia == null)
            {
                return NotFound();
            }

            var usuarioAgencia = await _context.UsuarioAgencia.FindAsync(id);
            if (usuarioAgencia == null)
            {
                return NotFound();
            }
            return View(usuarioAgencia);
        }

        // POST: UsuarioAgencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Conta,Agencia,permissao")] UsuarioAgencia usuarioAgencia)
        {
            if (id != usuarioAgencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioAgencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioAgenciaExists(usuarioAgencia.Id))
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
            return View(usuarioAgencia);
        }

        // GET: UsuarioAgencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuarioAgencia == null)
            {
                return NotFound();
            }

            var usuarioAgencia = await _context.UsuarioAgencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioAgencia == null)
            {
                return NotFound();
            }

            return View(usuarioAgencia);
        }

        // POST: UsuarioAgencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuarioAgencia == null)
            {
                return Problem("Entity set 'BancoContext.UsuarioAgencia'  is null.");
            }
            var usuarioAgencia = await _context.UsuarioAgencia.FindAsync(id);
            if (usuarioAgencia != null)
            {
                _context.UsuarioAgencia.Remove(usuarioAgencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioAgenciaExists(int id)
        {
          return (_context.UsuarioAgencia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
