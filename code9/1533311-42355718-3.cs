    Payment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private decimal _principalAmount;
        public decimal PrincipalAmount
        {
            get { return _principalAmount; }
            set
            {
                _principalAmount = value;
                NotifyPropertyChanged(nameof(PrincipalAmount));
                // lets the design know that property "TotalAmount" should also be updated ...
                NotifyPropertyChanged(nameof(TotalAmount));
            }
        }
    }
