        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
        if (!Equals(storage, value))
        {
            storage = value;
            RaisePropertyChanged(propertyName);
        }
        }
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
