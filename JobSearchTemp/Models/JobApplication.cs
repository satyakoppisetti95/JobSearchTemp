using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.Models
{
    public class JobApplication
    {
        [Key]
        public int JobApplicationId { get; set; }
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }
        public int JobPostingId { get; set; }
        public virtual JobPosting JobPosting { get; set; }
        public DateTime AppliedDate { get; set; }
        public int ResumeId { get; set; }
        public virtual Resume Resume { get; set; }

    }
}
