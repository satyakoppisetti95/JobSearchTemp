
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSearch.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSearchTemp.Data
{
    public class JobsDBContext : DbContext
    {
        public JobsDBContext(DbContextOptions<JobsDBContext> options) : base(options)
        {
           
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<SavedSearch> SavedSearches { get; set; }

    }
}
