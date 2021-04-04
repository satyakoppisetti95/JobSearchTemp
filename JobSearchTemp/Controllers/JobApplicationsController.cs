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
    public class JobApplicationsController : Controller
    {
        private readonly JobsDBContext _context;

        public JobApplicationsController(JobsDBContext context)
        {
            _context = context;
        }

        // GET: JobApplications
        public async Task<IActionResult> Index()
        {
            var jobsDBContext = _context.JobApplications.Include(j => j.Candidate).Include(j => j.JobPosting).Include(j => j.Resume);
            return View(await jobsDBContext.ToListAsync());
        }

        // GET: JobApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .Include(j => j.Candidate)
                .Include(j => j.JobPosting)
                .Include(j => j.Resume)
                .FirstOrDefaultAsync(m => m.JobApplicationId == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // GET: JobApplications/Create
        public IActionResult Create()
        {
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "CandidateId", "CandidateId");
            ViewData["JobPostingId"] = new SelectList(_context.JobPostings, "JobId", "JobId");
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "ResumeId", "ResumeId");
            return View();
        }

        // POST: JobApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobApplicationId,CandidateId,JobPostingId,AppliedDate,ResumeId")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "CandidateId", "CandidateId", jobApplication.CandidateId);
            ViewData["JobPostingId"] = new SelectList(_context.JobPostings, "JobId", "JobId", jobApplication.JobPostingId);
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "ResumeId", "ResumeId", jobApplication.ResumeId);
            return View(jobApplication);
        }

        // GET: JobApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication == null)
            {
                return NotFound();
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "CandidateId", "CandidateId", jobApplication.CandidateId);
            ViewData["JobPostingId"] = new SelectList(_context.JobPostings, "JobId", "JobId", jobApplication.JobPostingId);
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "ResumeId", "ResumeId", jobApplication.ResumeId);
            return View(jobApplication);
        }

        // POST: JobApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobApplicationId,CandidateId,JobPostingId,AppliedDate,ResumeId")] JobApplication jobApplication)
        {
            if (id != jobApplication.JobApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicationExists(jobApplication.JobApplicationId))
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
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "CandidateId", "CandidateId", jobApplication.CandidateId);
            ViewData["JobPostingId"] = new SelectList(_context.JobPostings, "JobId", "JobId", jobApplication.JobPostingId);
            ViewData["ResumeId"] = new SelectList(_context.Resumes, "ResumeId", "ResumeId", jobApplication.ResumeId);
            return View(jobApplication);
        }

        // GET: JobApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .Include(j => j.Candidate)
                .Include(j => j.JobPosting)
                .Include(j => j.Resume)
                .FirstOrDefaultAsync(m => m.JobApplicationId == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // POST: JobApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);
            _context.JobApplications.Remove(jobApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(e => e.JobApplicationId == id);
        }
    }
}
