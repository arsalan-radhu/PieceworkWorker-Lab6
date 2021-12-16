/*
 * Name: Arsalan Arif Radhu
 * Date: 4 December 2021
 * Modified: 15 December 2021
 * Student ID: 100813965
 * Description: Workers Controller
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PieceworkWorker_Lab6.Context;
using PieceworkWorker_Lab6.Models;
using Microsoft.AspNetCore.Authorization;

namespace PieceworkWorker_Lab6.Controllers
{
    [Authorize]
    public class WorkersController : Controller
    {
        private readonly PieceworkWorkerContext _context;

        public WorkersController(PieceworkWorkerContext context)
        {
            _context = context;
        }

        // GET: Workers
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.PieceworkWorkers.ToListAsync());
        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceWorkWorkerModel = await _context.PieceworkWorkers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pieceWorkWorkerModel == null)
            {
                return NotFound();
            }

            return View(pieceWorkWorkerModel);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from over-posting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Messages,isSenior")] PieceWorkWorkerModel pieceWorkWorkerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pieceWorkWorkerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pieceWorkWorkerModel);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceWorkWorkerModel = await _context.PieceworkWorkers.FindAsync(id);
            if (pieceWorkWorkerModel == null)
            {
                return NotFound();
            }
            return View(pieceWorkWorkerModel);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Messages,isSenior")] PieceWorkWorkerModel pieceWorkWorkerModel)
        {
            if (id != pieceWorkWorkerModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pieceWorkWorkerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieceWorkWorkerModelExists(pieceWorkWorkerModel.ID))
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
            return View(pieceWorkWorkerModel);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceWorkWorkerModel = await _context.PieceworkWorkers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pieceWorkWorkerModel == null)
            {
                return NotFound();
            }

            return View(pieceWorkWorkerModel);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pieceWorkWorkerModel = await _context.PieceworkWorkers.FindAsync(id);
            _context.PieceworkWorkers.Remove(pieceWorkWorkerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieceWorkWorkerModelExists(int id)
        {
            return _context.PieceworkWorkers.Any(e => e.ID == id);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Summary()
        {
            return View(await _context.PieceworkWorkers.ToListAsync());
        }
    }
}
