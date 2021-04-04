using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.Models
{
    public class SavedSearch
    {
        [Key]
        public int SavedSearchId { get; set; }
        public int CandidateId { get; set; }
        public  Candidate Candidate;
        public int JobPostingId { get; set; }
        public  JobPosting Job;


    }
}
