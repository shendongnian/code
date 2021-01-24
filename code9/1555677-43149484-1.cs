    class DateViewModel : NotifyPropertyChangedBase
    {
        private int _dayNumber;
        private bool _isCurrent;
        public int DayNumber
        {
            get { return _dayNumber; }
            set { _UpdateField(ref _dayNumber, value); }
        }
        public bool IsCurrent
        {
            get { return _isCurrent; }
            set { _UpdateField(ref _isCurrent, value); }
        }
    }
