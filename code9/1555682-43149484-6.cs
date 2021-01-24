    class MonthViewViewModel : NotifyPropertyChangedBase
    {
        private readonly ObservableCollection<DateViewModel> _dates = new ObservableCollection<DateViewModel>();
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { _UpdateField(ref _selectedDate, value); }
        }
        public IReadOnlyCollection<DateViewModel> Dates
        {
            get { return _dates; }
        }
        protected override void _OnPropertyChanged(string propertyName)
        {
            base._OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case nameof(SelectedDate):
                    _UpdateDates();
                    break;
            }
        }
        private void _UpdateDates()
        {
            _dates.Clear();
            DateTime firstDayOfMonth = new DateTime(SelectedDate.Year, SelectedDate.Month, 1),
                firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);
            int previousMonthDates = (int)firstDayOfMonth.DayOfWeek; // assumes Sunday-start week
            int daysInView = previousMonthDates + DateTime.DaysInMonth(SelectedDate.Year, SelectedDate.Month);
            // round up to nearest week multiple
            daysInView = ((daysInView - 1) / 7 + 1) * 7;
            DateTime previousMonth = firstDayOfMonth.AddDays(-previousMonthDates);
            for (DateTime date = previousMonth; date < firstDayOfNextMonth; date = date.AddDays(1))
            {
                _dates.Add(new DateViewModel { DayNumber = date.Day, IsCurrent = date == SelectedDate.Date });
            }
            for (int i = 1; _dates.Count < daysInView; i++)
            {
                _dates.Add(new DateViewModel { DayNumber = i, IsCurrent = false });
            }
        }
    }
