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
        public Candidate Candidate;
        public JobPosting Job;


    }
}
