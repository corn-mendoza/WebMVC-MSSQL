using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMVC_MSSQL.Models;

namespace WebMVC_MSSQL.Views
{
    public class ReleaseNotesController : Controller
    {
        private readonly ReleaseContext _context;

        public ReleaseNotesController(ReleaseContext context)
        {
            _context = context;    
        }

        // GET: ReleaseNotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReleaseNotes.ToListAsync());
        }

        // GET: ReleaseNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var releaseNote = await _context.ReleaseNotes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (releaseNote == null)
            {
                return NotFound();
            }

            return View(releaseNote);
        }

        // GET: ReleaseNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReleaseNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data")] ReleaseNote releaseNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(releaseNote);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(releaseNote);
        }

        // GET: ReleaseNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var releaseNote = await _context.ReleaseNotes.SingleOrDefaultAsync(m => m.Id == id);
            if (releaseNote == null)
            {
                return NotFound();
            }
            return View(releaseNote);
        }

        // POST: ReleaseNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data")] ReleaseNote releaseNote)
        {
            if (id != releaseNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(releaseNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReleaseNoteExists(releaseNote.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(releaseNote);
        }

        // GET: ReleaseNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var releaseNote = await _context.ReleaseNotes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (releaseNote == null)
            {
                return NotFound();
            }

            return View(releaseNote);
        }

        // POST: ReleaseNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var releaseNote = await _context.ReleaseNotes.SingleOrDefaultAsync(m => m.Id == id);
            _context.ReleaseNotes.Remove(releaseNote);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReleaseNoteExists(int id)
        {
            return _context.ReleaseNotes.Any(e => e.Id == id);
        }
    }
}
