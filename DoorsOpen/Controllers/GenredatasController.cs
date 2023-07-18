using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoorsOpen.Data;
using DoorsOpen.Models;

namespace DoorsOpen.Controllers
{
    public class GenredatasController : Controller
    {
        private readonly DoorsOpenContext _context;

        public GenredatasController(DoorsOpenContext context)
        {
            _context = context;
        }

        // GET: Genredatas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Genredata.ToListAsync());
        }

        // GET: Genredatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Genredata == null)
            {
                return NotFound();
            }

            var genredata = await _context.Genredata
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genredata == null)
            {
                return NotFound();
            }

            return View(genredata);
        }

        // GET: Genredatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genredatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Icon,Genreinfo")] Genredata genredata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genredata);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genredata);
        }

        // GET: Genredatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Genredata == null)
            {
                return NotFound();
            }

            var genredata = await _context.Genredata.FindAsync(id);
            if (genredata == null)
            {
                return NotFound();
            }
            return View(genredata);
        }

        // POST: Genredatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Icon,Genreinfo")] Genredata genredata)
        {
            if (id != genredata.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genredata);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenredataExists(genredata.Id))
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
            return View(genredata);
        }

        // GET: Genredatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Genredata == null)
            {
                return NotFound();
            }

            var genredata = await _context.Genredata
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genredata == null)
            {
                return NotFound();
            }

            return View(genredata);
        }

        // POST: Genredatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Genredata == null)
            {
                return Problem("Entity set 'DoorsOpenContext.Genredata'  is null.");
            }
            var genredata = await _context.Genredata.FindAsync(id);
            if (genredata != null)
            {
                _context.Genredata.Remove(genredata);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenredataExists(int id)
        {
          return _context.Genredata.Any(e => e.Id == id);
        }
    }
}
