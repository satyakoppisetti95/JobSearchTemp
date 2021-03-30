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
        public Candidate Candidate { get; set; }
        public JobPosting Job { get; set; }
        public DateTime AppliedDate { get; set; }

        public Resume Resume { get; set; }

    }
}
