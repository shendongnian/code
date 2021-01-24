    public class YourViewModel : INotifyPropertyChanged 
    {
        DateTime _startdate;
        public DateTime StartDate
        {
            get
            {   
                    return _startdate;
            }
            set
            {
                _startdate = value;
                RaisePropertyChanged("StartDate");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
