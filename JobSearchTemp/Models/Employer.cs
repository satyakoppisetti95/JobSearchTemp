using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.Models
{
    public class Employer
    {
        [Key]
        public int EmployerID { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Company { get; set; }
        public string Mobile { get; set; }
        public string Website { get; set; }

        public List<JobPosting> JobPostings { get; set; }
    }
}
