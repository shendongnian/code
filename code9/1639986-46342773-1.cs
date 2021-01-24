        protected void SetProperty<T>(ref T propertyToSet, T value, [CallerMemberName]string propertyName=null)
        {
            if(!propertyToSet.Equals(value))
            {
                propertyToSet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
