    class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
            _RaisePropertyChanged(propertyName);
        }
        protected void _RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
