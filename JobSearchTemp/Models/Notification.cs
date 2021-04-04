using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public int EmployerId { get; set; }
        public  virtual Employer Employer { get; set; }
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; }
    }
}
