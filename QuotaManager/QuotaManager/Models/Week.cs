using System;

namespace QuotaManager.Models
{
    public class Week
    {
        public DateTime weekStart { get; set; }
        public DateTime weekEnd { get; set; }
        public string weekStartString { get; set; }
        public string weekEndString { get; set; }

        public Week(DateTime weekStart, DateTime weekEnd)
        {
            this.weekStart = weekStart;
            this.weekEnd = weekEnd;
            this.weekStartString = weekStart.ToString("yyyy-MM-dd");
            this.weekEndString = weekEnd.ToString("yyyy-MM-dd");
        }
    }
}