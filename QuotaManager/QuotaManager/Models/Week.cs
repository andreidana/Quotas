using System;

namespace QuotaManager.Models
{
    public class Week
    {
        public DateTime weekStart { get; set; }
        public DateTime weekEnd { get; set; }
        public string weekStartString { get; set; }
        public string weekEndString { get; set; }
    }
}