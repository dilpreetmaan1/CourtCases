using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourtCases.Models
{
    public class CaseMaster
    {
        public int ID { get; set; }
        public int JudgeMastersID { get; set; }
        public int PartiesID { get; set; }
        public int LawyerMasterID { get; set; }
        public string CaseName { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string Type { get; set; }

        public JudgeMasters JudgeMasters { get; set; }
        public Parties Parties { get; set; }
        public LawyerMaster LawyerMaster { get; set; }
        public List<HearingMaster> HearingMasters { get; set; }
    }
}