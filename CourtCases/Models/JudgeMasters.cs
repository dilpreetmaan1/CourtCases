using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourtCases.Models
{
    public class JudgeMasters
    {
        public int ID { get; set; }
        public string JudgeName { get; set; }
        public string Speciality { get; set; }
        public string Age { get; set; }

        public List<CaseMaster> CaseMasters { get; set; }
    }
}