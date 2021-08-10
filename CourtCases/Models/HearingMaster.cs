using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourtCases.Models
{
    public class HearingMaster
    {
        public int ID { get; set; }
        public int CaseMasterID { get; set; }
        public Nullable<DateTime> CurrentDate { get; set; }
        public Nullable<DateTime> NextDate { get; set; }

        public CaseMaster CaseMaster { get; set; }
    }
}