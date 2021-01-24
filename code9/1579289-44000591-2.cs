        public string TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                if (_totalAmount == value) return;
                _totalAmount = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(TotalAmount)));
            }
        }
        private void UpdateAmount()
        {
            double sum = 0;
            foreach (var u in TrsFundDocItems)
            {
                sum += u.Amount;
            }
            TotalAmount = sum.ToString("c");
        }
