using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourtCases.Models
{
    public class Parties
    {
        public int ID { get; set; }
        public string ApplicantName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public List<CaseMaster> CaseMasters { get; set; }
    }
}