    public class currBetrag : INotifyPropertyChanged
    {
        private decimal _bttoBetrag;
        public decimal BttoBetrag
        {
            get { return _bttoBetrag; }
            set
            {
                _bttoBetrag = value;
                OnPropertyChanged();
                CalculateAusgabe("BttoBetrag");
            }
        }
        private decimal _uStBetrag;
        public decimal UStBetrag
        {
            get { return _uStBetrag; }
            set
            {
                _uStBetrag = value;
                OnPropertyChanged();
                CalculateAusgabe("UStBetrag");
            }
        }
        private void CalculateAusgabe(string colName)
        {
            if (USt == null) return;
            switch (colName)
            {
                //set the value of all fields...
                _uStBetrag = ?;
            }
            //and raise the PropertyChanged event for all involved properties
            OnPropertyChanged("UStBetrag");
            OnPropertyChanged("NttoBetrag");
            //...
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
         }
    }
