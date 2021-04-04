using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSearch.Models;
using JobSearchTemp.Data;

namespace JobSearchTemp.Controllers
{
    public class ResumesController : Controller
    {
        private readonly JobsDBContext _context;

        public ResumesController(JobsDBContext context)
        {
            _context = context;
        }

        // GET: Resumes
        public async Task<IActionResult> Index()
        {
            var jobsDBContext = _context.Resumes.Include(r => r.Candidate);
            return View(await jobsDBContext.ToListAsync());
        }

        // GET: Resumes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resume = await _context.Resumes
                .Include(r => r.Candidate)
                .FirstOrDefaultAsync(m => m.ResumeId == id);
            if (resume == null)
            {
                return NotFound();
            }

            return View(resume);
        }

        // GET: Resumes/Create
        public IActionResult Create()
        {
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "CandidateId", "CandidateId");
            return View();
        }

        // POST: Resumes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResumeId,CandidateId,education,experience,skills")] Resume resume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "CandidateId", "CandidateId", resume.CandidateId);
            return View(resume);
        }

        // GET: Resumes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resume = await _context.Resumes.FindAsync(id);
            if (resume == null)
            {
                return NotFound();
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "CandidateId", "CandidateId", resume.CandidateId);
            return View(resume);
        }

        // POST: Resumes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResumeId,CandidateId,education,experience,skills")] Resume resume)
        {
            if (id != resume.ResumeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResumeExists(resume.ResumeId))
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
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "CandidateId", "CandidateId", resume.CandidateId);
            return View(resume);
        }

        // GET: Resumes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resume = await _context.Resumes
                .Include(r => r.Candidate)
                .FirstOrDefaultAsync(m => m.ResumeId == id);
            if (resume == null)
            {
                return NotFound();
            }

            return View(resume);
        }

        // POST: Resumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resume = await _context.Resumes.FindAsync(id);
            _context.Resumes.Remove(resume);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResumeExists(int id)
        {
            return _context.Resumes.Any(e => e.ResumeId == id);
        }
    }
}
