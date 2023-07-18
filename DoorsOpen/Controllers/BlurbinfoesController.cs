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
    public class BlurbinfoesController : Controller
    {
        private readonly DoorsOpenContext _context;

        public BlurbinfoesController(DoorsOpenContext context)
        {
            _context = context;
        }

        // GET: Blurbinfoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Blurbinfo.ToListAsync());
        }

        // GET: Blurbinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blurbinfo == null)
            {
                return NotFound();
            }

            var blurbinfo = await _context.Blurbinfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blurbinfo == null)
            {
                return NotFound();
            }

            return View(blurbinfo);
        }

        // GET: Blurbinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blurbinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Image,Blurb")] Blurbinfo blurbinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blurbinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blurbinfo);
        }

        // GET: Blurbinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Blurbinfo == null)
            {
                return NotFound();
            }

            var blurbinfo = await _context.Blurbinfo.FindAsync(id);
            if (blurbinfo == null)
            {
                return NotFound();
            }
            return View(blurbinfo);
        }

        // POST: Blurbinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Image,Blurb")] Blurbinfo blurbinfo)
        {
            if (id != blurbinfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blurbinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlurbinfoExists(blurbinfo.Id))
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
            return View(blurbinfo);
        }

        // GET: Blurbinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Blurbinfo == null)
            {
                return NotFound();
            }

            var blurbinfo = await _context.Blurbinfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blurbinfo == null)
            {
                return NotFound();
            }

            return View(blurbinfo);
        }

        // POST: Blurbinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Blurbinfo == null)
            {
                return Problem("Entity set 'DoorsOpenContext.Blurbinfo'  is null.");
            }
            var blurbinfo = await _context.Blurbinfo.FindAsync(id);
            if (blurbinfo != null)
            {
                _context.Blurbinfo.Remove(blurbinfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlurbinfoExists(int id)
        {
          return _context.Blurbinfo.Any(e => e.Id == id);
        }
    }
}
