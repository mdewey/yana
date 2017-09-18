using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackOverflow.Data;
using StackOverflow.Models;

namespace StackOverflow.Controllers
{
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnswersModel.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answersModel = await _context.AnswersModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (answersModel == null)
            {
                return NotFound();
            }

            return View(answersModel);
        }
          [Authorize]
        // GET: Answers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VoteCount,Body,UserID,PostDate,QuestionID")] AnswersModel answersModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(answersModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(answersModel);
        }
         [Authorize]
        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answersModel = await _context.AnswersModel.SingleOrDefaultAsync(m => m.Id == id);
            if (answersModel == null)
            {
                return NotFound();
            }
            return View(answersModel);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VoteCount,Body,UserID,PostDate,QuestionID")] AnswersModel answersModel)
        {
            if (id != answersModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswersModelExists(answersModel.Id))
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
            return View(answersModel);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answersModel = await _context.AnswersModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (answersModel == null)
            {
                return NotFound();
            }

            return View(answersModel);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answersModel = await _context.AnswersModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.AnswersModel.Remove(answersModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswersModelExists(int id)
        {
            return _context.AnswersModel.Any(e => e.Id == id);
        }
    }
}
