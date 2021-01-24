    class ViewModel : INotifyPropertyChanged
    {
        private double _progressValue;
        public double ProgressValue
        {
            get { return _progressValue; }
            set { _UpdatePropertyField(ref _progressValue, value); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void _UpdatePropertyField<T>(
            ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
