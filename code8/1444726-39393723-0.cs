    public class UpdateDateViewModel:INotifyPropertyChanged
    {
        private DateTime _customerTally;
        public UpdateDateViewModel()
        {
            CustomerLastTally = DateTime.Today.AddDays(-1);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public DateTime CustomerLastTally
        {
            get { return _customerTally; }
            set
            {
                if (_customerTally != value)
                {
                    _customerTally = value;
                    updateWebservice();
                    OnPropertyChanged("CustomerLastTally");
                }
            }
        }
        private void updateWebservice()
        {
            
        }
    }
