    class ViewModel : INotifyPropertyChanged
    {
        private int _sampleCount;
        public int SampleCount
        {
            get { return _sampleCount; }
            set { _UpdateField(ref _sampleCount, value, OnCountChanged); }
        }
        private int _calibratorCount;
        public int CalibratorCount
        {
            get { return _calibratorCount; }
            set { _UpdateField(ref _calibratorCount, value, OnCountChanged); }
        }
        private int _controlCount;
        public int ControlCount
        {
            get { return _controlCount; }
            set { _UpdateField(ref _controlCount, value, OnCountChanged); }
        }
        private int _totalPrepCount;
        public int TotalPrepCount
        {
            get { return _totalPrepCount; }
            set { _UpdateField(ref _totalPrepCount, value); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnCountChanged(int previousValue)
        {
            TotalPrepCount = SampleCount + CalibratorCount + ControlCount;
        }
        protected void _UpdateField<T>(ref T field, T newValue,
            Action<T> onChangedCallback = null,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return;
            }
            T oldValue = field;
            field = newValue;
            onChangedCallback?.Invoke(oldValue);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
