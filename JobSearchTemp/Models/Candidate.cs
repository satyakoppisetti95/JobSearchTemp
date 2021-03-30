using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; } 

        public string EmailId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Skills { get; set; }

        public string registration_date { get; set; }

    }
}
