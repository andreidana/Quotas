using QuotaManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using Windows.Storage;

namespace QuotaManager.DatesList
{
    public class WeeksList
    {
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;

        public List<Week> Weeks { get; }

        public WeeksList()
        {
            Weeks = new List<Week>();
            SetFirstWeek();
            AddAllWeeksToList();
        }

        private void AddAllWeeksToList()
        {
            var lastDayOfCurrentWeek = Weeks[0].weekEnd;
            while (DateTime.Now > lastDayOfCurrentWeek)
            {
                var week = ConstructWeek(lastDayOfCurrentWeek.AddDays(1));
                Weeks.Add(week);
                lastDayOfCurrentWeek = week.weekEnd;
            }
        }

        private void SetFirstWeek()
        {
            var startDate = Convert.ToDateTime(_localSettings.Values["startDate"]);
            var week = ConstructWeek(startDate);
            Weeks.Add(week);
        }

        private Week ConstructWeek(DateTime startDate)
        {
            var weekStart = GetFirstDayOfWeek(startDate);
            var weekEnd = weekStart.AddDays(7);
            return new Week(weekStart, weekEnd);
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