using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.Models
{
    public class JobPosting
    {
        [Key]
        public int JobId {get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public int EmployerId { get; set; }
        public virtual Employer employer { get; set; }
        public Boolean IsActive { get; set; }

    }
}
