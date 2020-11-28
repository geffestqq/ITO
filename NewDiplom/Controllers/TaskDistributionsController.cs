using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewDiplom.Models;

namespace NewDiplom.Controllers
{
    public class TaskDistributionsController : Controller
    {
        private readonly DiplomContext _context;

        public TaskDistributionsController(DiplomContext context)
        {
            _context = context;
        }

        // GET: TaskDistributions
        public async Task<IActionResult> Index()
        {
            _context.Zadachis.Load();
            _context.Employees.Load();
            _context.Positions.Load();
            var diplomContext = _context.TaskDistributions.Include(t => t.Plurality).Include(t => t.Status).Include(t => t.Zadachi);
            return View(await diplomContext.ToListAsync());
        }

        // GET: TaskDistributions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDistribution = await _context.TaskDistributions
                .Include(t => t.Plurality)
                .Include(t => t.Status)
                .Include(t => t.Zadachi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskDistribution == null)
            {
                return NotFound();
            }

            _context.Zadachis.Load();
            _context.Employees.Load();
            _context.Positions.Load();
            return View(taskDistribution);
        }

        // GET: TaskDistributions/Create
        public IActionResult Create()
        {
            _context.Zadachis.Load();
            _context.Employees.Load();
            _context.Positions.Load();
            ViewData["PluralityId"] = new SelectList(_context.Plurality, "Id", "View");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Status_name");
            ViewData["ZadachiId"] = new SelectList(_context.Zadachis, "Id", "View");
            return View();
        }

        // POST: TaskDistributions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartedAt,PeriodUnit,PeriodValue,PluralityId,ZadachiId,StatusId")] TaskDistribution taskDistribution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskDistribution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            _context.Zadachis.Load();
            _context.Employees.Load();
            _context.Positions.Load();
            ViewData["PluralityId"] = new SelectList(_context.Plurality, "Id", "View", taskDistribution.PluralityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Status_name", taskDistribution.StatusId);
            ViewData["ZadachiId"] = new SelectList(_context.Zadachis, "Id", "View", taskDistribution.ZadachiId);
            return View(taskDistribution);
        }

        // GET: TaskDistributions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDistribution = await _context.TaskDistributions.FindAsync(id);
            if (taskDistribution == null)
            {
                return NotFound();
            }
            _context.Zadachis.Load();
            _context.Employees.Load();
            _context.Positions.Load();
            ViewData["PluralityId"] = new SelectList(_context.Plurality, "Id", "View", taskDistribution.PluralityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Status_name", taskDistribution.StatusId);
            ViewData["ZadachiId"] = new SelectList(_context.Zadachis, "Id", "View", taskDistribution.ZadachiId);
            return View(taskDistribution);
        }

        // POST: TaskDistributions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartedAt,PeriodUnit,PeriodValue,PluralityId,ZadachiId,StatusId")] TaskDistribution taskDistribution)
        {
            if (id != taskDistribution.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskDistribution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskDistributionExists(taskDistribution.Id))
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
            _context.Zadachis.Load();
            _context.Employees.Load();
            _context.Positions.Load();
            ViewData["PluralityId"] = new SelectList(_context.Plurality, "Id", "View", taskDistribution.PluralityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Status_name", taskDistribution.StatusId);
            ViewData["ZadachiId"] = new SelectList(_context.Zadachis, "Id", "View", taskDistribution.ZadachiId);
            return View(taskDistribution);
        }

        // GET: TaskDistributions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDistribution = await _context.TaskDistributions
                .Include(t => t.Plurality)
                .Include(t => t.Status)
                .Include(t => t.Zadachi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskDistribution == null)
            {
                return NotFound();
            }

            _context.Zadachis.Load();
            _context.Employees.Load();
            _context.Positions.Load();

            return View(taskDistribution);
        }

        // POST: TaskDistributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskDistribution = await _context.TaskDistributions.FindAsync(id);
            _context.TaskDistributions.Remove(taskDistribution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskDistributionExists(int id)
        {
            return _context.TaskDistributions.Any(e => e.Id == id);
        }
    }
}
