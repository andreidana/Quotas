using System;
using System.Collections.Generic;
using System.Globalization;
using Windows.Storage;
using QuotaManager.Models;

namespace QuotaManager.DatesList
{
    public class WeeksList
    {
        private DateTime _startDate;
        private DateTime _currentDate;
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;

        public List<Week> Weeks { get; }

        public WeeksList()
        {
            _startDate = Convert.ToDateTime(_localSettings.Values["startDate"]);
            _currentDate = DateTime.Now;
            Weeks = new List<Week>();
            var firstWeek = new Week {weekStart = GetFirstDayOfWeek(_startDate), weekStartString = GetFirstDayOfWeek(_startDate).ToString("yyyy-MM-dd") };
            firstWeek.weekEnd = firstWeek.weekStart.AddDays(7);
            firstWeek.weekEndString = firstWeek.weekEnd.ToString("yyyy-MM-dd");
            Weeks.Add(firstWeek);
        }

        private DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            var defaultCultureInfo = CultureInfo.CurrentCulture;
            return CalculateStartOfFirstWeek(dayInWeek, defaultCultureInfo);
        }

        private DateTime CalculateStartOfFirstWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            var firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var firstDayInWeek = dayInWeek.Date;

            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }

            return firstDayInWeek;
        }
    }
}