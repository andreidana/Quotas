using System;
using System.Collections.Generic;
using System.Globalization;
using Windows.Storage;
using QuotaManager.Models;

namespace QuotaManager.DatesList
{
    public class DatesList
    {
        private DateTime _startDate;
        private DateTime _currentDate;
        private List<Week> _weeks;
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        
        public DatesList()
        {
            _startDate = Convert.ToDateTime(_localSettings.Values["startDate"]);
            _currentDate = DateTime.Now;
            _weeks = new List<Week>();
            var firstWeek = new Week {weekStart = GetFirstDayOfWeek(_startDate)};
            firstWeek.weekEnd = firstWeek.weekStart.AddDays(7);
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