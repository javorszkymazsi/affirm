using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AffirmationsApp.Data;
using AffirmationsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AffirmationsApp.Controllers
{
    [Authorize]
    public class AffirmationsController : Controller
    {
        private readonly ApplicationDbContext _appDb;
        private readonly AffirmationsAppContext _identityDb;

        private readonly UserManager<IdentityUser> _userManager;

        public AffirmationsController(ApplicationDbContext appContext, AffirmationsAppContext identityDb, UserManager<IdentityUser> userManager)
        {
            _appDb = appContext;
            _identityDb = identityDb;
            _userManager = userManager;
        }

        // GET: Affirmations
        public async Task<IActionResult> Index()
        {
            return View(await _appDb.Affirmation.ToListAsync());
        }

        // GET: Affirmations/UserAffirmations
        public async Task<IActionResult> UserAffirmations()
        {
            var userId = _userManager.GetUserId(User); // Get the logged-in user's ID
            var userName = _userManager.GetUserName(User); // Get the logged-in user's username

            // Fetch affirmations for the current user
            var affirmations = await _appDb.Affirmation
                .Where(a => a.User == userId)
                .ToListAsync();

            return View(affirmations);
        }

        // GET: Affirmations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affirmation = await _appDb.Affirmation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (affirmation == null)
            {
                return NotFound();
            }

            return View(affirmation);
        }

        // GET: Affirmations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Affirmations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,Language")] Affirmation affirmation)
        {
            if (ModelState.IsValid)
            {
                _appDb.Add(affirmation);
                await _appDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(affirmation);
        }

        // GET: Affirmations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affirmation = await _appDb.Affirmation.FindAsync(id);
            if (affirmation == null)
            {
                return NotFound();
            }
            return View(affirmation);
        }

        // POST: Affirmations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text")] Affirmation affirmation)
        {
            if (id != affirmation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appDb.Update(affirmation);
                    await _appDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AffirmationExists(affirmation.Id))
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
            return View(affirmation);
        }

        // GET: Affirmations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affirmation = await _appDb.Affirmation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (affirmation == null)
            {
                return NotFound();
            }

            return View(affirmation);
        }

        // POST: Affirmations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var affirmation = await _appDb.Affirmation.FindAsync(id);
            if (affirmation != null)
            {
                _appDb.Affirmation.Remove(affirmation);
            }

            await _appDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AffirmationExists(int id)
        {
            return _appDb.Affirmation.Any(e => e.Id == id);
        }
    }
}
