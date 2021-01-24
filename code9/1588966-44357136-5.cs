    public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //if using c# 6.0 or later replace the above with
        //public void RaisePropertyChanged(string propertyName)=>
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
