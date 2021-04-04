using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.Models
{
    public class Resume
    {
        [Key]
        public int ResumeId { get; set; }
        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public string education { get; set; }
        public string experience { get; set; }
        public string skills { get; set; }

    }
}
