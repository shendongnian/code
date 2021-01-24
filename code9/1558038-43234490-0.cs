        public void NewOnPropertyChanged<T>(ref T variable, T value, [CallerMemberName] string propertyName = "")
        {
            variable = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalCost"));
        }
