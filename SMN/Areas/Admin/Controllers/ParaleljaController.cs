using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMN.Data;
using SMN.Data.Entities;

namespace SMN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ParaleljaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParaleljaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Paraleljas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Paralelja.Include(p => p.Kujdestari);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Paraleljas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paralelja = await _context.Paralelja
                .Include(p => p.Kujdestari)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paralelja == null)
            {
                return NotFound();
            }

            return View(paralelja);
        }

        // GET: Admin/Paraleljas/Create
        public IActionResult Create()
        {
            ViewData["KujdestariId"] = new SelectList(_context.SmnUser, "Id", "Id");
            return View();
        }

        // POST: Admin/Paraleljas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Klasa,VitiShkollor,NumriParaleles,KujdestariId")] Paralelja paralelja)
        {
            if (ModelState.IsValid)
            {
                paralelja.Id = Guid.NewGuid();
                _context.Add(paralelja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KujdestariId"] = new SelectList(_context.SmnUser, "Id", "Id", paralelja.KujdestariId);
            return View(paralelja);
        }

        // GET: Admin/Paraleljas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paralelja = await _context.Paralelja.FindAsync(id);
            if (paralelja == null)
            {
                return NotFound();
            }
            ViewData["KujdestariId"] = new SelectList(_context.SmnUser, "Id", "Id", paralelja.KujdestariId);
            return View(paralelja);
        }

        // POST: Admin/Paraleljas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Klasa,VitiShkollor,NumriParaleles,KujdestariId")] Paralelja paralelja)
        {
            if (id != paralelja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paralelja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParaleljaExists(paralelja.Id))
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
            ViewData["KujdestariId"] = new SelectList(_context.SmnUser, "Id", "Id", paralelja.KujdestariId);
            return View(paralelja);
        }

        // GET: Admin/Paraleljas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paralelja = await _context.Paralelja
                .Include(p => p.Kujdestari)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paralelja == null)
            {
                return NotFound();
            }

            return View(paralelja);
        }

        // POST: Admin/Paraleljas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var paralelja = await _context.Paralelja.FindAsync(id);
            _context.Paralelja.Remove(paralelja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParaleljaExists(Guid id)
        {
            return _context.Paralelja.Any(e => e.Id == id);
        }
    }
}
